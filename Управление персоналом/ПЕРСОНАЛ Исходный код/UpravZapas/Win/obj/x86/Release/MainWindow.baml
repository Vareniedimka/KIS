   M S B A M L   `   `   `  ����   Win    Win.MainWindow   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$+  %Управление запасами��$	��389��$	��629�� J� IsHitTestVisible . |�. $	��629��$	��389�� � Icon$* $/Win;component/Images/phppg_3471.png��.��� $
��Auto��$
��Auto�� � RowDefinitions �� $
��Auto ��� $
��352* ��� $��25 � � ColumnDefinitions �� $
��Auto ��� $
��432* ��� $
��Auto �.+��� -   $��	statusBar��$��3��$��3��$��Stretch=�$	��1,0q�$��Bottom=�$��30��.@��� -   $��statusLabel��$�� ��$y�Visible=�&   System.Windows.Controls.DataGrid  -     Name$ 	dgRabociy��$��1��$��1��   
IsReadOnly .    AutoGenerateColumns .  $y�Hidden=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$#	 Табельный номер��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 ��  �� Path$ 
Tabeln_nom�  $	 Зарег брак��
 �� $ 
Zareg_brak�  $	 Фио��
 �� $	 FIO�  -   $ dgProfessii��$��1��$��1�� .  .  $y�Hidden=�   $	 Ставка в час��
 �� $ Stavka_v_chas�  $	 Наименование��
 �� $ Naimenovanie�  $	 Разряд��
 �� $ Razryad_rabochego�  -   $ dgZarplatnay_vedom��$��1��$��1�� .  .  $y�Hidden=�   $	 Запралата��
 �� $ Zarabotn_Plata�  $	 ФИО��
 �� $	 FIO�o� -   $��mainMenu��$��25��$��Stretch=�$	��Top=�$��3�� . .@�m� -   $��DataBase��$��База данных��.@�m� -   $��	dataBaseS��$H��BНастроить соединение с имеющейся БД��m� -	   $��About��$��О программе���� $��1��$��0�� �� Orientation$ Vertical=�.+��� -
   $��
bPostavhik��$��75��$��50������ .+��� $��Center=�$��1q�$��10(�Профессии�� -   $��bZakaz��$��75��$��50������ .+��� $��Center=�$��1q�$��10(�Рабочий � ToolTip �� (&Информация о товарах�� -   $��
bMateriali��$��75��$��50������ .+��� $��Center=�$��1q�$��10(�Ведомость�� $��Center=�$��1q�$��10(�о зарплате�� $��2��$��1��$ Vertical=�.+��� -   $
��bAdd��$��60��$��60������ .+��� $��71��$-��'/Win;component/Images/edit-add_9258.png��$��36��}�.  |�.  � ForceCursor .  � DataContext ��  � BindingGroup &   System.Windows.Data.BindingGroup  �� $��Center=�$��1q�$��10(�Добавить �� *(Добавить новую запись�� -   $��bEdit��$��60��$��60������ .+��� $��71��$$��/Win;component/Images/text.png��$��34��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Изменить �� Изменение�� -   $��bDelete��$��60��$��60������ .+��� $��71��$*��$/Win;component/Images/error_2262.png��$��38��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Удалить �� 20Удаление выбранной записи�� -   $��bReload��$��60��$��60������ .+��� $��71��$0��*/Win;component/Images/gtk-refresh_4743.png��$��38��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Обновить �� Обновление�� -   $��bFind��$��60��$��60������ .+��� $��71��$$��/Win;component/Images/find.png��$��39��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�
Поиск �� 
Поиск