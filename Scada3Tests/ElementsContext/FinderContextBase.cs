namespace Scada3Tests.ElementsContext 
{
	internal class FinderContextBase
	{
		/// <summary>
		/// Форма для авторизации в Заре
		/// </summary>
		public const string FormForAuthorization = nameof(FormForAuthorization);
		/// <summary>
		///Логин для авторизации
		/// </summary>
		public const string Login = nameof(Login);
		/// <summary>
		///Пароль для авторизации
		/// </summary>
		public const string Password = nameof(Password);
		/// <summary>
		///Кнопка для отправки данных авторизацииы
		/// </summary>
		public const string FormForAuthorizationButtonEntry = nameof(FormForAuthorizationButtonEntry);
		/// <summary>
		///Имя вкладки "Главная"
		/// </summary>
		public const string MainPageName = nameof(MainPageName);
		/// <summary>
		///Заголовок плитки "Диагностика системы" на вкладке "Главная"
		/// </summary>
		public const string DiagnosticSystemTailOnMainPage = nameof(DiagnosticSystemTailOnMainPage);
		/// <summary>
		///Плитка "Версия ПО"
		/// </summary>
		public const string VersionTail = nameof(VersionTail);
		/// <summary>
		///Каналы связи: на странице "Главная"
		/// </summary>
		public const string MainPageSTChannelConnect = nameof(MainPageSTChannelConnect);
		/// <summary>
		///СОЕВ: на странице "Главная"
		/// </summary>
		public const string MainPageSTCoeb = nameof(MainPageSTCoeb);
		/// <summary>
		///Собрано: на странице "Главная"
		/// </summary>
		public const string MainPageSTCollected = nameof(MainPageSTCollected);
		/// <summary>
		/// "Всего:" на странице "Главная"
		/// </summary>
		public const string MainPageSTTotal = nameof(MainPageSTTotal);
		/// <summary>
		///На контроле: на странице "Главная"
		/// </summary>
		public const string MainPageSTOnControl = nameof(MainPageSTOnControl);
		/// <summary>
		///Без контроля: на странице "Главная" (таблица)
		/// </summary>
		public const string MainPageSTWithoutControlTable = nameof(MainPageSTWithoutControlTable);
		/// <summary>
		///Контроль отставания данных на странице "Главная"
		/// </summary>
		public const string MainPageSTLagData = nameof(MainPageSTLagData);
		/// <summary>
		///Дубликаты каналов на странице "Главная"
		/// </summary>
		public const string MainPageSTDuplicatesChannels = nameof(MainPageSTDuplicatesChannels);
		/// <summary>
		///Разница времени на странице "Главная"
		/// </summary>
		public const string MainPageSTDiffTime = nameof(MainPageSTDiffTime);
		/// <summary>
		///Дубликаты сетевых адресов на странице "Главная"
		/// </summary>
		public const string MainPageSTLanAddressDup = nameof(MainPageSTLanAddressDup);
		/// <summary>
		///Дубликаты на странице "Главная"
		/// </summary>
		public const string MainPageSTDuplicates = nameof(MainPageSTDuplicates);
		/// <summary>
		///Без контроля на странице "Главная" 
		/// </summary>
		public const string MainPageSTWithoutControl = nameof(MainPageSTWithoutControl);
		/// <summary>
		///Паспорта каналов на странице "Главная"
		/// </summary>
		public const string MainPageSTChannelPasport = nameof(MainPageSTChannelPasport);
		/// <summary>
		///Плюс крутящийся на странице "Главная"
		/// </summary>
		public const string MainPageSTPlusRotate = nameof(MainPageSTPlusRotate);
		/// <summary>
		///Минус крутящийся нас странице "Главная"
		/// </summary>
		public const string MainPageSTMinusRotate = nameof(MainPageSTMinusRotate);
		/// <summary>
		///Имя вкладки "Управление абонентами"
		/// </summary>
		public const string SubscrMan = nameof(SubscrMan);
		/// <summary>
		///Вращающийся плюс "Управление абонентами"
		/// </summary>
		public const string SubscrManPlus = nameof(SubscrManPlus);
		/// <summary>
		///Имя вкладки "Абоненты"
		/// </summary>
		public const string AbonentsPage = nameof(AbonentsPage);
		/// <summary>
		///Выберите объект из дерева адресов на странице "Абоненты"
		/// </summary>
		public const string AbonentsPageChoose = nameof(AbonentsPageChoose);
		/// <summary>
		///Имя вкладки "Абоненты мини"
		/// </summary>
		public const string AbonentsPageMini = nameof(AbonentsPageMini);
		/// <summary>
		///Регион (Область) на странице "Абоненты" (css)
		/// </summary>
		public const string AbonentsPageSTRegion = nameof(AbonentsPageSTRegion);
		/// <summary>
		///Пиктограмма "Дом" (Регион) на странице "Абоненты"
		/// </summary>
		public const string AbonentsPageSTHouse = nameof(AbonentsPageSTHouse);
		/// <summary>
		///Информация по объекту на странице "Абоненты" (клик на Регион)
		/// </summary>
		public const string AbonentsPageSTInfo = nameof(AbonentsPageSTInfo);
		/// <summary>
		///Редактирование:  на странице "Абоненты" (клик на Регион)
		/// </summary>
		public const string AbonentsPageSTEdit = nameof(AbonentsPageSTEdit);
		/// <summary>
		///Регион (Область) на странице "Абоненты" (xpath)
		/// </summary>
		public const string AbonentsPageSTRegionX = nameof(AbonentsPageSTRegionX);
		/// <summary>
		///Пустая область на странице "Абоненты" поле "Адреса"
		/// </summary>
		public const string AbonentsPageSTFreeSpace = nameof(AbonentsPageSTFreeSpace);
		/// <summary>
		///Проверить по абонентской информации на странице "Абоненты", поле "Связь" (правая кнопка мыши)
		/// </summary>
		public const string AbonentsPageSTCheckAbonents = nameof(AbonentsPageSTCheckAbonents);
		/// <summary>
		///Добавить в абонентский список на странице "Абоненты", поле "Связь" (правая кнопка мыши)
		/// </summary>
		public const string AbonentsPageSTAddToAbonList = nameof(AbonentsPageSTAddToAbonList);
		/// <summary>
		///Экспорт абонентской информации на странице "Абоненты", поле "Связь" (правая кнопка мыши)
		/// </summary>
		public const string AbonentsPageSTExportAbonInfo = nameof(AbonentsPageSTExportAbonInfo);
		/// <summary>
		///Имя вкладки "Балансы"
		/// </summary>
		public const string BalancePage = nameof(BalancePage);
		/// <summary>
		///Надпись "Нет балансных групп" на странице "Балансы"
		/// </summary>
		public const string BalancePageNoGroup = nameof(BalancePageNoGroup);
		/// <summary>
		///Имя вкладки "Балансы мини"
		/// </summary>
		public const string BalancePageMini = nameof(BalancePageMini);
		/// <summary>
		///Календарь на странице "Балансы мини"
		/// </summary>
		public const string BalancePageMiniCalendar = nameof(BalancePageMiniCalendar);
		/// <summary>
		///Канал №01 на странице "Балансы"
		/// </summary>
		public const string BalancePageSTChannel1 = nameof(BalancePageSTChannel1);
		/// <summary>
		///Географический регион на странице "Балансы" (надпись)
		/// </summary>
		public const string BalancePageSTGeoRegion = nameof(BalancePageSTGeoRegion);
		/// <summary>
		///Абоненты на странице "Балансы" (вкладка)
		/// </summary>
		public const string BalancePageSTAbonents = nameof(BalancePageSTAbonents);
		/// <summary>
		///Связь на странице "Балансы" (вкладка)
		/// </summary>
		public const string BalancePageSTConnection = nameof(BalancePageSTConnection);
		/// <summary>
		///Энергосистема на странице "Балансы"
		/// </summary>
		public const string BalancePageSTPowerSystem = nameof(BalancePageSTPowerSystem);
		/// <summary>
		///Балансная группа на странице "Балансы", меню "Географический регион"
		/// </summary>
		public const string BalancePageSTBalanceGroup = nameof(BalancePageSTBalanceGroup);
		/// <summary>
		///Географический субрегион на странице "Балансы", меню "Географический регион"
		/// </summary>
		public const string BalancePageSTGeoSubRegion = nameof(BalancePageSTGeoSubRegion);
		/// <summary>
		///Группа отчетов на странице "Балансы", меню "Географический регион"
		/// </summary>
		public const string BalancePageSTReportGroup = nameof(BalancePageSTReportGroup);
		/// <summary>
		///Процессы объекта на странице "Балансы", меню "Географический регион"
		/// </summary>
		public const string BalancePageSTObjProc = nameof(BalancePageSTObjProc);
		/// <summary>
		///Изменить тип каналов на странице "Балансы", меню "Связь" (Канал №01)
		/// </summary>
		public const string BalancePageSTChannelTypeChange = nameof(BalancePageSTChannelTypeChange);
		/// <summary>
		///Стрелка для раскрытия списка каналов на странице "Балансы" (Регион(Область))
		/// </summary>
		public const string BalancePageSTArrowRegion = nameof(BalancePageSTArrowRegion);
		/// <summary>
		///Экспорт на странице "Балансы", меню "Абоненты" (Регион - Канал №01)
		/// </summary>
		public const string BalancePageSTExport = nameof(BalancePageSTExport);
		/// <summary>
		///Импорт на странице "Балансы", меню "Абоненты" (Регион - Канал №01)
		/// </summary>
		public const string BalancePageSTImport = nameof(BalancePageSTImport);
		/// <summary>
		///Канал №01 на странице "Балансы", вкладка "Регион (Область)"
		/// </summary>
		public const string BalancePageSTChannel1Region = nameof(BalancePageSTChannel1Region);
		/// <summary>
		///Имя вкладки "Графики"
		/// </summary>
		public const string GraphsPage = nameof(GraphsPage);
		/// <summary>
		///Кнопка "Построить график" на странице "Графики"
		/// </summary>
		public const string GraphsPageButtonBuild = nameof(GraphsPageButtonBuild);
		/// <summary>
		///Алерт "Выберите объекты" на странице "Графики"
		/// </summary>
		public const string GraphsPageChooseObj = nameof(GraphsPageChooseObj);
		/// <summary>
		///Кнопка "Добавить объекты" на странице "Графики"
		/// </summary>
		public const string GraphsPageAddObj = nameof(GraphsPageAddObj);
		/// <summary>
		///Стрелка, разворачивающая список "Канала" на странице "Графики", кнопка "Добавить объекты" (МК, Счетчики и т.д.)
		/// </summary>
		public const string GraphsPageArrowList = nameof(GraphsPageArrowList);
		/// <summary>
		///Квадрат для чекбокса у "Канал 01" на странице "Графики"
		/// </summary>
		public const string GraphsPageSqrAll = nameof(GraphsPageSqrAll);
		/// <summary>
		///Квадрат для чекбокса у "МК-01", "Канал 01" на странице "Графики"
		/// </summary>
		public const string GraphsPageSqrMk = nameof(GraphsPageSqrMk);
		/// <summary>
		///Квадрат для чекбокса у "счетчик 1", "Канал 01" на странице "Графики"
		/// </summary>
		public const string GraphsPageSqr1 = nameof(GraphsPageSqr1);
		/// <summary>
		///Квадрат для чекбокса у "счетчик 2", "Канал 01" на странице "Графики"
		/// </summary>
		public const string GraphsPageSqr2 = nameof(GraphsPageSqr2);
		/// <summary>
		///Квадрат для чекбокса у "счетчик 3", "Канал 01" на странице "Графики"
		/// </summary>
		public const string GraphsPageSqr3 = nameof(GraphsPageSqr3);
		/// <summary>
		///Квадрат для чекбокса под кнопкой "Добавить объекты" на странице "Графики"
		/// </summary>
		public const string GraphPageCheckBoxAddObj = nameof(GraphPageCheckBoxAddObj);
		/// <summary>
		///Кнопка "Добавить каналы" на странице "Графики"
		/// </summary>
		public const string GraphPageAddChannels = nameof(GraphPageAddChannels);
		/// <summary>
		///Квадрат для чекбокса у "Активная прямая, Суточный архив", "Добавить каналы" на странице "Графики"
		/// </summary>
		public const string GraphPageActiveLineDay = nameof(GraphPageActiveLineDay);
		/// <summary>
		///Квадрат для чекбокса у "Напряжение, Мгновенное значение", "Добавить каналы" на странице "Графики"
		/// </summary>
		public const string GraphPageVoltageInstVal = nameof(GraphPageVoltageInstVal);
		/// <summary>
		///Квадрат для чекбокса у "Активная прямая, Суточный архив", под кнопкой "Добавить каналы" на странице "Графики"
		/// </summary>
		public const string GraphPageActiveLineDayUnder = nameof(GraphPageActiveLineDayUnder);
		/// <summary>
		///Квадрат для чекбокса у "Напряжение, Мгновенное значение", под кнопкой "Добавить каналы" на странице "Графики"
		/// </summary>
		public const string GraphPageVoltageInstValUnder = nameof(GraphPageVoltageInstValUnder);
		/// <summary>
		///Кнопка "Принять" в окне "Измерительные каналы" на странице "Графики" (Добавить каналы)
		/// </summary>
		public const string GraphPageButtonAcceptAddChannels = nameof(GraphPageButtonAcceptAddChannels);
		/// <summary>
		///Кнопка "Еще" в окне "Измерительные каналы" на странице "Графики" (Добавить каналы)
		/// </summary>
		public const string GraphPageButtonOther = nameof(GraphPageButtonOther);
		/// <summary>
		///Имя вкладки "Диагностика НСД"
		/// </summary>
		public const string DiagNSD = nameof(DiagNSD);
		/// <summary>
		///Надпись "Диагностика системы" на странице "Диагностика НСД"
		/// </summary>
		public const string DiagNSDDiagSystem = nameof(DiagNSDDiagSystem);
		/// <summary>
		///Обслуживание вкладка "Отладка"
		/// </summary>
		public const string DiagnosticDebaggingPage = nameof(DiagnosticDebaggingPage);
		/// <summary>
		///Удалить отладку надпись на странице "Отладка" в "Обслуживание"
		/// </summary>
		public const string DiagnosticDebaggingPageDelDiag = nameof(DiagnosticDebaggingPageDelDiag);
		/// <summary>
		///Обслуживание вкладка "База данных"
		/// </summary>
		public const string DiagnosticDatabasePage = nameof(DiagnosticDatabasePage);
		/// <summary>
		///Имя сервера БД надпись на странице "База данных" в "Обслуживание"
		/// </summary>
		public const string DiagnosticDatabasePageNameBD = nameof(DiagnosticDatabasePageNameBD);
		/// <summary>
		///Обслуживание вкладка "О сервере"
		/// </summary>
		public const string DiagnosticAboutServerPage = nameof(DiagnosticAboutServerPage);
		/// <summary>
		///Информация о сервере надпись на странице "О сервере" в "Обслуживание"
		/// </summary>
		public const string DiagnosticAboutServerPageInfo = nameof(DiagnosticAboutServerPageInfo);
		/// <summary>
		///Обслуживание вкладка "Процессы"
		/// </summary>
		public const string DiagnosticProcessPage = nameof(DiagnosticProcessPage);
		/// <summary>
		///Список процессов сервера надпись на странице "Процессы" в "Обслуживание"
		/// </summary>
		public const string DiagnosticProcessPageList = nameof(DiagnosticProcessPageList);
		/// <summary>
		///Обслуживание вкладка "Программы"
		/// </summary>
		public const string DiagnosticProgrammPage = nameof(DiagnosticProgrammPage);
		/// <summary>
		///Установленные программы надпись на странице "Программы" в "Обслуживание"
		/// </summary>
		public const string DiagnosticProgrammPageInstProg = nameof(DiagnosticProgrammPageInstProg);
		/// <summary>
		///Обслуживание вкладка "Порты"
		/// </summary>
		public const string DiagnosticPortsPagePorts = nameof(DiagnosticPortsPagePorts);
		/// <summary>
		///Порты надпись на странице "Порты" в "Обслуживание"
		/// </summary>
		public const string DiagnosticPortsPage = nameof(DiagnosticPortsPage);
		/// <summary>
		///Обслуживание вкладка "Редактор АП"
		/// </summary>
		public const string DiagnosticEditorPage = nameof(DiagnosticEditorPage);
		/// <summary>
		/// Пиктограмма "Структура связи" (вышка с радиоволнами) 
		/// </summary>
		public const string DiagnosticEditorPageBrTower = nameof(DiagnosticEditorPageBrTower);
		/// <summary>
		///Обслуживание вкладка "Управление расписанием"
		/// </summary>
		public const string DiagnosticScheManagPage = nameof(DiagnosticScheManagPage);
		/// <summary>
		///Количество групп расписания на странице "Управление расписанием" в "Обслуживание"
		/// </summary>
		public const string DiagnosticScheManagPageScheGr = nameof(DiagnosticScheManagPageScheGr);
		/// <summary>
		///Обслуживание вкладка "Управление отладкой"
		/// </summary>
		public const string DiagnosticDebagManagPage = nameof(DiagnosticDebagManagPage);
		/// <summary>
		///Кнопка "Сохранить" на странице "Управление отладкой" в "Обслуживание"
		/// </summary>
		public const string DiagnosticDebagManagPageSaveB = nameof(DiagnosticDebagManagPageSaveB);
		/// <summary>
		///Вкладка Обслуживание
		/// </summary>
		public const string DiagnosticDebagTab = nameof(DiagnosticDebagTab);
		/// <summary>
		/// Имя вкладки "Интеграция"
		/// </summary>
		public const string IntegrationPage = nameof(IntegrationPage);
		/// <summary>
		/// Пиктограмма "Ручной запрос" (ладонь)
		/// </summary>
		public const string IntegrationPagePicto = nameof(IntegrationPagePicto);
		/// <summary>
		///Календарь на страницах
		/// </summary>
		public const string DateTimeRangeComp = nameof(DateTimeRangeComp);
		/// <summary>
		///Кнопка "Связь" возле поиска на странице "Абоненты мини"
		/// </summary>
		public const string MirDialogComTextForConnection = nameof(MirDialogComTextForConnection);
		/// <summary>
		///
		/// </summary>
		public const string MirMatTreeNodeCom = nameof(MirMatTreeNodeCom);
		/// <summary>
		///Пустая область на странице без вкладок (белая)
		/// </summary>
		public const string TabContent = nameof(TabContent);
		/// <summary>
		///Элемент для закрытия вкладки в заре
		/// </summary>
		public const string TabClose = nameof(TabClose);
		/// <summary>
		///Кнопка меню в Заре
		/// </summary>
		public const string MenuButtonMirBurger = nameof(MenuButtonMirBurger);
		/// <summary>
		///Отчеты в главном меню
		/// </summary>
		public const string ReportsPage = nameof(ReportsPage);
		/// <summary>
		///[1.1] Акт счет по потребителям вкладка "Отчеты"
		/// </summary>
		public const string ReportsPageAct11 = nameof(ReportsPageAct11);
		/// <summary>
		///Отчет не был запрошен на странице "Отчеты", вкладка "[1.1] Акт счет по потребителям"
		/// </summary>
		public const string ReportsPageAct11NotReq = nameof(ReportsPageAct11NotReq);
		/// <summary>
		///Отчет не был запрошен на странице "Импорт/Экспорт", вкладка "[1.1] ГорСети"
		/// </summary>
		public const string ImportExportPageGorSet11NotReq = nameof(ImportExportPageGorSet11NotReq);
		/// <summary>
		/// "Импорт/Экспорт" в главном меню
		/// </summary>
		public const string ImportExportPage = nameof(ImportExportPage);
		/// <summary>
		///[1.1] ГорСети вкладка "Импорт/Экспорт"
		/// </summary>
		public const string ImportExportPageGorSet11 = nameof(ImportExportPageGorSet11);
		/// <summary>
		///Имя вкладки "Права доступа"
		/// </summary>
		public const string AccessRightsPage = nameof(AccessRightsPage);
		/// <summary>
		///Группы пользователей на странице "Права доступа"
		/// </summary>
		public const string AccessRightsPageUserGr = nameof(AccessRightsPageUserGr);
		/// <summary>
		///Имя вкладки "Протокол"
		/// </summary>
		public const string ProtocolPage = nameof(ProtocolPage);
		/// <summary>
		///"Свойства на вкладке ""Редактор компонентов"" Скада3"
		/// </summary>
		public const string ComponentsEditorTabProperties = nameof(ComponentsEditorTabProperties);
		/// <summary>
		///"Примитивы на вкладке ""Редактор компонентов"" Скада3"
		/// </summary>
		public const string ComponentsEditorTabPrimitives = nameof(ComponentsEditorTabPrimitives);
		/// <summary>
		///"Компоненты на вкладке ""Редактор компонентов"" Скада3"
		/// </summary>
		public const string ComponentsEditorTabComponents = nameof(ComponentsEditorTabComponents);
		/// <summary>
		///"Верхняя панель инструментов на вкладке ""Редактор компонентов"" Скада3"
		/// </summary>
		public const string ComponentsEditorTabToolbar = nameof(ComponentsEditorTabToolbar);
		/// <summary>
		///Дерево компонентов
		/// </summary>
		public const string ComponentEditorTreeComponents = nameof(ComponentEditorTreeComponents);
		/// <summary>
		///Узел в дереве компонентов
		/// </summary>
		public const string NodeTreeComponents = nameof(NodeTreeComponents);
		/// <summary>
		///Кнопка открытия компонента
		/// </summary>
		public const string NodeTreeComponentsBtnOpenComponent = nameof(NodeTreeComponentsBtnOpenComponent);
		/// <summary>
		///Вся область,где разворачивается открытый компонент
		/// </summary>
		public const string ComponentEditorDivSpace = nameof(ComponentEditorDivSpace);
		/// <summary>
		///Первый открытый компонент
		/// </summary>
		public const string ComponentEditorFirstOpenComponent = nameof(ComponentEditorFirstOpenComponent);
		/// <summary>
		///Кнопка плюс для добавления нового компонента в список
		/// </summary>
		public const string ComponenEditorBtnAddNewComponent = nameof(ComponenEditorBtnAddNewComponent);
		/// <summary>
		///Кнопка ручка для редактирования имени компонента в списке
		/// </summary>
		public const string ComponenEditorBtnRenameComponent = nameof(ComponenEditorBtnRenameComponent);
		/// <summary>
		///Кнопка  корзина для удаления  компонента из списка
		/// </summary>
		public const string ComponenEditorBtnDeleteComponent = nameof(ComponenEditorBtnDeleteComponent);
		/// <summary>
		///Поле ввода имени для нового компонента
		/// </summary>
		public const string ComponentEditorInputNameNewComponent = nameof(ComponentEditorInputNameNewComponent);
		/// <summary>
		///Кнопка создать в модальном окне
		/// </summary>
		public const string ComponentEditorBtnCreateInModalWindow = nameof(ComponentEditorBtnCreateInModalWindow);
		/// <summary>
		///Кнпока для экспорта компонента в файл
		/// </summary>
		public const string ComponentEditroBtnExportFile = nameof(ComponentEditroBtnExportFile);
		/// <summary>
		///Кнпока для импорта компонента в файл
		/// </summary>
		public const string ComponentEditroBtnImportFile = nameof(ComponentEditroBtnImportFile);
		/// <summary>
		///"Схемы" на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabSchemes = nameof(SchemeEditorTabSchemes);
		/// <summary>
		///"Объекты" на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabElements = nameof(SchemeEditorTabElements);
		/// <summary>
		///Рабочая область на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabWorkSpace = nameof(SchemeEditorTabWorkSpace);
		/// <summary>
		///Верхняя панель инструментов на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabToolbar = nameof(SchemeEditorTabToolbar);
		/// <summary>
		///"Свойства" на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabProperties = nameof(SchemeEditorTabProperties);
		/// <summary>
		///"Библиотека" на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabLibrary = nameof(SchemeEditorTabLibrary);
		/// <summary>
		///"Слои" на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabLayers = nameof(SchemeEditorTabLayers);
		/// <summary>
		///"История" на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabHistory = nameof(SchemeEditorTabHistory);
		/// <summary>
		///"Графика" на рабочей области, вкладка "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabGraphics = nameof(SchemeEditorTabGraphics);
		/// <summary>
		///"Модель" на рабочей области, вкладка "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabModel = nameof(SchemeEditorTabModel);
		/// <summary>
		///"Телемеханика" на рабочей области, вкладка "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabTelemechanics = nameof(SchemeEditorTabTelemechanics);
		/// <summary>
		///"Симулятор" на рабочей области, вкладка "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabSimulator = nameof(SchemeEditorTabSimulator);
		/// <summary>
		///Тестовая папка на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabTestFolder = nameof(SchemeEditorTabTestFolder);
		/// <summary>
		///Тестовая схема "autotest" на вкладке "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabTestScheme = nameof(SchemeEditorTabTestScheme);
		/// <summary>
		///Стрелка для раскрытия папки со схемами Скада3
		/// </summary>
		public const string SchemeEditorTabSchemesArrow = nameof(SchemeEditorTabSchemesArrow);
		/// <summary>
		///Дерево элементов в "Элементы", вкладка "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabElemTree = nameof(SchemeEditorTabElemTree);
		/// <summary>
		///"Свойства полотна" в свойствах, вкладка "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabCanvasProperties = nameof(SchemeEditorTabCanvasProperties);
		/// <summary>
		///"Открыть схему", правая кнопка мыши, "Схемы", вкладка "Редактор схем" Скада3
		/// </summary>
		public const string SchemeEditorTabOpenScheme = nameof(SchemeEditorTabOpenScheme);
		/// <summary>
		///Первая папка в списке, вкладка "Редактор схем"
		/// </summary>
		public const string SchemeEditorTabFirstFolder = nameof(SchemeEditorTabFirstFolder);
		/// <summary>
		///Имя вкладки "Связь"
		/// </summary>
		public const string ConnectionPage = nameof(ConnectionPage);
		/// <summary>
		///Значок возле "Канал №01" на странице "Связь" (пиктограмма)
		/// </summary>
		public const string ConnectionPagePicto = nameof(ConnectionPagePicto);
		/// <summary>
		///Вкладка "Связь" на странице "Связь"
		/// </summary>
		public const string ConnectionPageSTConnect = nameof(ConnectionPageSTConnect);
		/// <summary>
		///Вкладка "Праметры" на странице "Связь"
		/// </summary>
		public const string ConnectionPageSTParameters = nameof(ConnectionPageSTParameters);
		/// <summary>
		///Пиктограмма "Изменить тип счетчиков" на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTChangeTypePicto = nameof(ConnectionPageSTChangeTypePicto);
		/// <summary>
		///Пиктограмма "Создать" (плюс) на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTCreatePicto = nameof(ConnectionPageSTCreatePicto);
		/// <summary>
		///Пиктограмма "Команды" (инструменты) на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTCommandsPicto = nameof(ConnectionPageSTCommandsPicto);
		/// <summary>
		/// Пиктограмма "Обновить" на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTUpdatePicto = nameof(ConnectionPageSTUpdatePicto);
		/// <summary>
		///Пиктограмма "Копировать" на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTCopyPicto = nameof(ConnectionPageSTCopyPicto);
		/// <summary>
		///Пиктограмма "Удалить из системы" на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTDeletePicto = nameof(ConnectionPageSTDeletePicto);
		/// <summary>
		///Пиктограмма "Сортировать" на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTSortPicto = nameof(ConnectionPageSTSortPicto);
		/// <summary>
		///Пиктограмма "Экспорт каналов" на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTExportPicto = nameof(ConnectionPageSTExportPicto);
		/// <summary>
		///Пиктограмма "Создать карточку" (планшет) на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTCreateCardPicto = nameof(ConnectionPageSTCreateCardPicto);
		/// <summary>
		///Пиктограмма "Показать карточки" на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTShowCardPicto = nameof(ConnectionPageSTShowCardPicto);
		/// <summary>
		///Пиктограмма "Свернуть" (-) на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTMinusPicto = nameof(ConnectionPageSTMinusPicto);
		/// <summary>
		///Пиктограмма "Развернуть" (+) на странице "Связь" (правая кнопка мыши на Канал №01)
		/// </summary>
		public const string ConnectionPageSTPlusPicto = nameof(ConnectionPageSTPlusPicto);
		/// <summary>
		///Коррекция времени на странице "Связь" на вкладке "Параметры"
		/// </summary>
		public const string ConnectionPageSTTimeCorrection = nameof(ConnectionPageSTTimeCorrection);
		/// <summary>
		///Опрос данных на странице "Связь" на вкладке "Параметры"
		/// </summary>
		public const string ConnectionPageSTData = nameof(ConnectionPageSTData);
		/// <summary>
		///Списки индикации на странице "Связь" на вкладке "Параметры"
		/// </summary>
		public const string ConnectionPageSTListIndic = nameof(ConnectionPageSTListIndic);
		/// <summary>
		///Тарифные расписания на странице "Связь" на вкладке "Параметры"
		/// </summary>
		public const string ConnectionPageSTTarifList = nameof(ConnectionPageSTTarifList);
		/// <summary>
		///Критерии поиска на странице "Связь"
		/// </summary>
		public const string ConnectionPageCheckBy = nameof(ConnectionPageCheckBy);
		/// <summary>
		///Кнопка выбора критериев поиска на странице "Связь"
		/// </summary>
		public const string ConnectionPageCheckFind = nameof(ConnectionPageCheckFind);
		/// <summary>
		///Строка поиска на странице "Связь"
		/// </summary>
		public const string ConnectionPageFindString = nameof(ConnectionPageFindString);
		/// <summary>
		///Название предложения по выбору на странице "Связь", строка поиска
		/// </summary>
		public const string ConnectionPageFindMK = nameof(ConnectionPageFindMK);
		/// <summary>
		///МИР МК-01 в Канал №01 на странице "Связь"
		/// </summary>
		public const string ConnectionPageMK = nameof(ConnectionPageMK);
		/// <summary>
		///"Кнопка ""Главное меню"" на главной странице Скада3"
		/// </summary>
		public const string MenuButtonMirBurgerScada3 = nameof(MenuButtonMirBurgerScada3);
		/// <summary>
		///"Вкладка ""Главная страница"" в Скада3"
		/// </summary>
		public const string MainPageTabScada3 = nameof(MainPageTabScada3);
		/// <summary>
		///"Вкладка ""Редактор схем"" в Скада3"
		/// </summary>
		public const string SchemeEditorTabScada3 = nameof(SchemeEditorTabScada3);
		/// <summary>
		///"Вкладка ""Редактор компонентов"" в Скада3"
		/// </summary>
		public const string ComponentsEditorTabScada3 = nameof(ComponentsEditorTabScada3);
		/// <summary>
		///"Вкладка ""Энергосистема"" в Скада3"
		/// </summary>
		public const string PowerSystemTabScada3 = nameof(PowerSystemTabScada3);
		/// <summary>
		///"Вкладка ""Сценарии"" в Скада3"
		/// </summary>
		public const string ScenariosTabScada3 = nameof(ScenariosTabScada3);
		/// <summary>
		///"Вкладка ""Связь"" в Скада3"
		/// </summary>
		public const string ConnectionTabScada3 = nameof(ConnectionTabScada3);
		/// <summary>
		///Добро пожаловать! на главной странице Скада3
		/// </summary>
		public const string MainPageTabScada3Hello = nameof(MainPageTabScada3Hello);
		/// <summary>
		///Кнопка отвечающая за масштаб в верхнем тулбаре
		/// </summary>
		public const string ToolbarBtnMenuTriggerExpamdWide = nameof(ToolbarBtnMenuTriggerExpamdWide);
		/// <summary>
		///Подложка выпадающего меню
		/// </summary>
		public const string ToolbarMatMenuContent = nameof(ToolbarMatMenuContent);
		/// <summary>
		///Кнпока увеличить масштаб
		/// </summary>
		public const string ToolbarBtnMenuTriggerToIncrement = nameof(ToolbarBtnMenuTriggerToIncrement);
		/// <summary>
		///Кнпока уменшить масштаб
		/// </summary>
		public const string ToolbarBtnMenuTriggerToDecrement = nameof(ToolbarBtnMenuTriggerToDecrement);
		/// <summary>
		///Кнопка восстановить масштаб
		/// </summary>
		public const string ToolbarBtnMenuTriggerRestoreScale = nameof(ToolbarBtnMenuTriggerRestoreScale);
		/// <summary>
		///Значение текущего масштаба
		/// </summary>
		public const string ToolbarZoomText = nameof(ToolbarZoomText);
		/// <summary>
		///"Имя пользователя", логин в Скада 3
		/// </summary>
		public const string ScadaLoginUser = nameof(ScadaLoginUser);
		/// <summary>
		///"Пароль", логин в Скада 3
		/// </summary>
		public const string ScadaLoginPassword = nameof(ScadaLoginPassword);
		/// <summary>
		///Кнопка "Вход" на странице логина в Скада 3
		/// </summary>
		public const string ScadaLoginButtonEnter = nameof(ScadaLoginButtonEnter);
		/// <summary>
		///Имя вкладки "Служба сбора"
		/// </summary>
		public const string CollectionServicePage = nameof(CollectionServicePage);
		/// <summary>
		///Статус службы сбора на странице "Служба сбора"
		/// </summary>
		public const string CollectionServicePageStatus = nameof(CollectionServicePageStatus);
		/// <summary>
		///Темы в главном меню
		/// </summary>
		public const string ThemesPage = nameof(ThemesPage);
		/// <summary>
		///Вестерос вкладка "Темы"
		/// </summary>
		public const string ThemesPageVesteros = nameof(ThemesPageVesteros);
		/// <summary>
		/// "Обслуживание", "Темы" в главном меню
		/// </summary>
		public const string DiagnosticThemesPage = nameof(DiagnosticThemesPage);
		/// <summary>
		///Обслуживание, "Вестерос" вкладка "Темы"
		/// </summary>
		public const string DiagnosticThemesPageVesteros = nameof(DiagnosticThemesPageVesteros);
		/// <summary>
		///Имя вкладки "Управление освещением"
		/// </summary>
		public const string LightCtrl = nameof(LightCtrl);
		/// <summary>
		///Лампочка на кнопке "Включить" на странице "Управление освещением"
		/// </summary>
		public const string LightCtrlBulb = nameof(LightCtrlBulb);
		/// <summary>
		///Кнопка "Включить" на странице "Управление освещением"
		/// </summary>
		public const string LightCtrlTurnOn = nameof(LightCtrlTurnOn);
		/// <summary>
		///Кнопка "Отключить" на странице "Управление освещением"
		/// </summary>
		public const string LightCtrlOff = nameof(LightCtrlOff);
		/// <summary>
		///Кнопка "Запросить U,I" на странице "Управление освещением"
		/// </summary>
		public const string LightCtrRequestUI = nameof(LightCtrRequestUI);
		/// <summary>
		///Кнопка "Запросить" на странице "Управление освещением"
		/// </summary>
		public const string LightCtrRequest = nameof(LightCtrRequest);
		/// <summary>
		///Кнопка "Выделить все" на странице "Управление освещением"
		/// </summary>
		public const string LightCtrSelectAll = nameof(LightCtrSelectAll);
		/// <summary>
		///Кнопка "Очистить" на странице "Управление освещением"
		/// </summary>
		public const string LightCtrClear = nameof(LightCtrClear);
		/// <summary>
		///Кнопка "Выполнить" на странице "Управление освещением"
		/// </summary>
		public const string LightCtrExecute = nameof(LightCtrExecute);
		/// <summary>
		///"shared works!" на вкладке "Энергосистема" Скада3
		/// </summary>
		public const string PowerSystemTabPoster = nameof(PowerSystemTabPoster);

	}
}