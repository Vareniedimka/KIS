   M S B A M L   `   `   `  ����   Win    Win.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$+  %Управление запасами��$	��541��$	��629�� J� IsHitTestVisible . |�. $	��629��$	��389�� � Icon$* $/Win;component/Images/phppg_3471.png��.��� $
��Auto��$
��Auto�� � RowDefinitions �� $
��Auto ��� $
��352* ��� $��25 � � ColumnDefinitions �� $
��Auto ��� $
��432* ��� $
��Auto �.+��� -   $��	statusBar��$��3��$��3��$��Stretch=�$	��1,0q�$��Bottom=�$��30��.@��� -   $��statusLabel��$�� ��$y�Visible=�&   System.Windows.Controls.DataGrid  -     Name$ dgZakaz��$��1��$��1��   
IsReadOnly .    AutoGenerateColumns .  $y�Hidden=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Поставщик��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 ��  �� Path$ PostavhikName�  $	 Материал��
 �� $ MaterialName�  $	 Количество��
 �� $ Kolichestvo�  $#	 Дата оформления��
 �� $ DataOformString�  $	 Статус��
 �� $ Status�  $	 Стоимость (р.)��
 �� $ Stoimost�  $	 Дата закрытия��
 �� $ DataVipolnString�  -   $ dgMaterialPostav��$��1��$��1�� .  .  $y�Hidden=�   $	 Поставщик��
 �� $ PostavhikName�  $	 Материал��
 �� $ MaterialName�  -   $ dgOtpuskSoSklada��$��1��$��1�� .  .  $y�Hidden=�   $	 Материал��
 �� $ MaterialName�  $	 Количество��
 �� $ Kolichestvo�  $	 Дата отгрузки��
 �� $ DataOtgruzkString�  -   $ 
dgMaterial��$��1��$��1�� .  .  $y�Hidden=�   $	 Название��
 �� $
 Name�  $	 Цена (р.)��
 �� $
 Cena�  $'	 !Единица измерения��
 �� $ EdinIzm�  -   $ dgPostavhik��$��1��$��1�� .  .  $y�Visible=�   $	 Название��
 �� $
 Name�  $	 
Адрес��
 �� $ Adres�  $	 Телефон��
 �� $ Phone�  $	 Номер счета��
 �� $ NomerScheta�  -   $ dgZapas��$��1��$��1�� .  .  $y�Hidden=�   $	 Матерьял��
 �� $ MaterialName�  $	 Количество��
 �� $ Kolichestvo�o� -	   $��mainMenu��$��25��$��Stretch=�$	��Top=�$��3�� . .@�m� -
   $��DataBase��$��База данных��.@�m� -   $��	dataBaseS��$��
Выход��m� -   $��Reports��$��Отчеты��.@�m� -   $��ExelExporterButton��$)��#Экспорт таблицы Excel��m� -   $��HtmlExporterBurron��$+��%Экспорт таблицы в html��m� -   $��About��$��О программе���� $��1��$��0�� �� Orientation$ Vertical=�.+��� -   $��
bPostavhik��$��75��$��80������ .+��� $��71��$'��!/Win;component/Images/clients.png��$��53��}�.  |�.  � ForceCursor .  � DataContext ��  � BindingGroup &   System.Windows.Data.BindingGroup  �� $��Center=�$��1q�$��10(�Поставщики�� -   $��bMaterialPostav��$��75��$��50������ .+��� $��Center=�$��1q�$��10(�Материал у�� $��Center=�$��1q�$��10(�поставщиков�� -   $��bOtpuskSoSklada��$��75��$��50������ .+��� $��Center=�$��1q�$��10(�Отпуск�� $��Center=�$��1q�$��10(�со склада�� -   $��bZakaz��$��75��$��50������ .+��� $��Center=�$��1q�$��10(�Заказы � ToolTip �� (&Информация о товарах�� -   $��bZapas��$��75��$��50������ .+��� $��Center=�$��1q�$��10(�Запасы�� -   $��
bMateriali��$��75��$��50������ .+��� $��Center=�$��1q�$��10(�Маткриалы�� $��2��$��1��$ Vertical=�.+��� -   $
��bAdd��$��60��$��60������ .+��� $��71��$-��'/Win;component/Images/edit-add_9258.png��$��36��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Добавить �� *(Добавить новую запись�� -   $��bEdit��$��60��$��60������ .+��� $��71��$$��/Win;component/Images/text.png��$��34��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Изменить �� Изменение�� -   $��bDelete��$��60��$��60������ .+��� $��71��$*��$/Win;component/Images/error_2262.png��$��38��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Удалить �� 20Удаление выбранной записи�� -   $��bReload��$��60��$��60������ .+��� $��71��$0��*/Win;component/Images/gtk-refresh_4743.png��$��38��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Обновить �� Обновление�� -   $��bFind��$��60��$��60������ .+��� $��71��$$��/Win;component/Images/find.png��$��39��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�
Поиск �� 
Поиск