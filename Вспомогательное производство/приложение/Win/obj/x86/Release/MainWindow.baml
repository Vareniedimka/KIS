   M S B A M L   `   `   `  ����   Win    Win.MainWindow   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$=  7Вспомогательное производство��$	��389��$	��629�� J� IsHitTestVisible . |�. $	��629��$	��389�� � Icon$* $/Win;component/Images/phppg_3471.png��.��� $
��Auto��$
��Auto�� � RowDefinitions �� $
��Auto ��� $
��352* ��� $��25 � � ColumnDefinitions �� $	��108 ��� $
��438* ��� $
��Auto �.+��� -   $��	statusBar��$��3��$��3��$��Stretch=�$	��1,0q�$��Bottom=�$��30��.@��� -   $��statusLabel��$�� ��$y�Visible=�&   System.Windows.Controls.DataGrid  -     Name$ dgDetdlyaremk��$��1��$��1��   
IsReadOnly .    AutoGenerateColumns .  $y�Hidden=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Наименование��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 ��  �� Path$ NaimenovanieDet�  $	 Количество��
 �� $ 
Kolichestv�  -   $ dgGraficRabot��$��1��$��1�� .  .  $y�Hidden=�   $'	 !Инвентарный номер��
 �� $ InvertatniyNomer�  $+	 %Наименование детали��
 �� $ NaimenovanieDet�  $*	 $Дата начала ремонта��
 �� $ DateNachRemont�  $0	 *Дата окончания ремонта��
 �� $ DataOkonchRem�  $)	 #Внеплановый ремонт��
 �� $ 	VnepanRem�  -   $ dgStanok_na_proizv��$��1��$��1�� .  .  $y�Hidden=�   $'	 !Инвентарный номер��
 �� $ Invertatniy_nomer�  $	 Год выпуска��
 �� $ God_vipuska�  $	 Модель��
 �� $ Model�  $9	 3Год введения в эксплуатацию��
 �� $ God_vvedeniya_v_expluat�o� -   $��mainMenu��$��25��$��Stretch=�$	��Top=�$��3�� . .@�m� -   $��DataBase��$��База данных��.@�m� -   $��	dataBaseS��$H��BНастроить соединение с имеющейся БД��m� -	   $��Reports��$��Отчеты��.@�m� -
   $��ExelExporterButton��$)��#Экспорт таблицы Excel��m� -   $��HtmlExporterBurron��$+��%Экспорт таблицы в html��m� -   $��About��$��О программе���� $��1�� �� Orientation$ Vertical=�$��2��$��	0,0,434,0q�.+��� -   $��bDetdlyarem��$	��104��$��50������ .+��� $��Center=�$��1q�$��10(�$"Детали для ремонта�� -   $��bGraficRabot��$	��102��$��50������ $��60��.+��� $��Center=�$��1q�$��10(�$��50��График�� $��Center=�$��1q�$��10(�$��52��
работ�� -   $��bStanok_na_proizv��$	��100��$��50������ .+��� $��Center=�$��1q�$��10(�Станок на�� $��Center=�$��1q�$��10(�производство�� $��2��$��1��$ Vertical=�.+��� -   $
��bAdd��$��60��$��60������ .+��� $��71��$-��'/Win;component/Images/edit-add_9258.png��$��36��}�.  |�.  � ForceCursor .  � DataContext ��  � BindingGroup &   System.Windows.Data.BindingGroup  �� $��Center=�$��1q�$��10(�Добавить � ToolTip �� *(Добавить новую запись�� -   $��bEdit��$��60��$��60������ .+��� $��71��$$��/Win;component/Images/text.png��$��34��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Изменить �� Изменение�� -   $��bDelete��$��60��$��60������ .+��� $��71��$*��$/Win;component/Images/error_2262.png��$��38��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Удалить �� 20Удаление выбранной записи�� -   $��bReload��$��60��$��60������ .+��� $��71��$0��*/Win;component/Images/gtk-refresh_4743.png��$��38��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�Обновить �� Обновление�� -   $��bFind��$��60��$��60������ .+��� $��71��$$��/Win;component/Images/find.png��$��39��}�.  |�.  .  ��    �� $��Center=�$��1q�$��10(�
Поиск �� 
Поиск