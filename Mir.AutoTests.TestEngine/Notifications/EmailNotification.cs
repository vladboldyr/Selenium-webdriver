using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Mir.AutoTests.TestEngine.Notifications
{
  public class EmailNotification : INotification
  {
    public EmailNotification(string mailServerHost, 
                             int mailServerport, 
                             string emailFrom, 
                             IReadOnlyCollection<string> emailsTo, 
                             string subject, 
                             string body, 
                             IReadOnlyCollection<string> logFilesNames, 
                             Dictionary<string, List<Screenshot>> screenshots)
    {
      _mailServerHost = mailServerHost ?? throw new ArgumentNullException(nameof(mailServerHost));
      _mailServerPort = mailServerport<0 || mailServerport > 65535 ? 
                        throw new ArgumentException(nameof(mailServerport)) : 
                        mailServerport;
      _emailFrom = emailFrom ?? throw new ArgumentNullException(nameof(emailFrom));
      _emailsTo = emailsTo?.Any() == true ? emailsTo : throw new ArgumentNullException(nameof(emailsTo));
      _subject = subject;
      _body = body;
      _logFilesNames = logFilesNames;
      _screenshots = screenshots;
    }
    public void SendNotification()
    {
      var mailMessage = new MailMessage()
      {
        From = new MailAddress(_emailFrom),
        Subject = string.IsNullOrWhiteSpace(_subject) ? string.Empty : _subject,
        Body = string.IsNullOrWhiteSpace(_body) ? string.Empty : _body
      };

      using (mailMessage)
      {
        foreach (var to in _emailsTo)
        {
          mailMessage.To.Add(to);
        }

        foreach (var logFile in _logFilesNames)
        {
          var attachment = new Attachment(logFile);
          mailMessage.Attachments.Add(attachment);
        }

        var memStreams = new List<MemoryStream>(_screenshots.Count);

        foreach (var screenshotsForTest in _screenshots)
        {
          int index = 0;
          foreach (var screenshot in screenshotsForTest.Value)
          {
            index++;
            var fileName = screenshotsForTest.Key + "(" + index + ").png";
            var memstr = new MemoryStream(screenshot.AsByteArray);
            memStreams.Add(memstr);
            mailMessage.Attachments.Add(new Attachment(memstr, fileName));
          }
        }

        using (var client = new SmtpClient(_mailServerHost, _mailServerPort))
        {
          client.Send(mailMessage);
        }
        foreach (var memstr in memStreams)
        {
          memstr.Dispose(); //Закрываем стрим для каждого скриншота
        }
      }
    }

    private string _mailServerHost;
    private int _mailServerPort;
    private string _emailFrom;
    private IReadOnlyCollection<string> _emailsTo;

    private string _subject;
    private string _body;

    private IReadOnlyCollection<string> _logFilesNames;
    private Dictionary<string, List<Screenshot>> _screenshots;
  }
}
