   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  j fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null=#clr-namespace:StAbraam.View.DialogsStAbraam.View.Dialogs &    StAbraam.View.Dialogs.EditClinic   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5local#clr-namespace:StAbraam.View.Dialogs       � Title$  
EditClinic��$	��240��$	��500�� � WindowStartupLocation$ CenterOwner=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .  .���� $��3q����	#FF444444 �� CornerRadius$ 3��._��  � RowDefinitions �� $��35 ��� ��  � ColumnDefinitions �� $	��100 ��� .+��� $��0��$��0��$��5q�$�� Landline :��$��Center=��� $��1��$��0��$��5q�$��	Address :��$��Center=��� $��0��$��1��$��5q�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 	Landline ������ *
Landline+	 �� ValidatesOnDataErrors	 . 
 �� UpdateSourceTrigger$
 PropertyChanged=� �� NotifyOnValidationError . � $��1��$��1�� �� �� �� .+��� $��0��$��5q�$	��200��$  Building No ������ *
BuildingNo+�� $��1��$��5q�$	��200��$  Street Name ������ *
StreetNo+�� $��2��$��5q�$	��200��$ 	District ������ *
District+	 . $
 PropertyChanged=� . � $��2��$��1�� �� $	��150 ��� .+��� $��0��$��Center=�$��5q�
���  ������ *UserMessage+��  �� Orientation$ 
Horizontal=�$��1��.+��� $��60��$��5q�$��35��$��Right=�$��Center=�$
��Save������ *
AddCommand+�� $��60��$��5q�$��35��$��Right=�$��Center=�$��Remove������ *RemoveCommand+�� $��60��$��5q�$��35��$��Right=�$��Center=�$��Cancel������ *CancelCommand+