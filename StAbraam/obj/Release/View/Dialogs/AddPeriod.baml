   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  j fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null=#clr-namespace:StAbraam.View.DialogsStAbraam.View.Dialogs %   StAbraam.View.Dialogs.AddPeriod   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:StAbraam.View.Dialogs       � Title$  	AddPeriod��$	��150��$	��500�� � WindowStartupLocation$ CenterOwner=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .  .���� $��3q����	#FF444444 �� CornerRadius$ 3��._�� .+��� $��Center=�$��Center=� �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� $��Center=�$��From : ��(  "System.Windows.Controls.DatePicker  $��2��$��1��$	��150��$��5q�$��Center=�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Select a date��   SelectedDate �� *
FromDate+	 �� ValidatesOnDataErrors	 . 
 �� UpdateSourceTrigger$
 PropertyChanged=� �� NotifyOnValidationError . �� $��Center=�$��To : ��  $��2��$��1��$	��150��$��5q�$��Center=�$ Select a date�� �� *ToDate+	 . $
 PropertyChanged=� . �� $ 
Horizontal=�.+��� $��	Months : ��$��5q��� $��5q����	#FF32A4C0$
��Bold"����� *Difference.Months+�� $��Weeks : ��$��5q��� $��5q����	#FF32A4C0$
��Bold"����� *Difference.Weeks+�� $��Days : ��$��5q��� $��5q����	#FF32A4C0$
��Bold"����� *Difference.Days+�� $��Center=�$��Center=�
���  ������ *UserMessage+�� $ 
Horizontal=�$��Bottom=�$��Right=�.+��� $��70��$��20��$��5q�$	��Add������ *
AddCommand+�� $��70��$��20��$��5q�$��Cancel������ *CancelCommand+