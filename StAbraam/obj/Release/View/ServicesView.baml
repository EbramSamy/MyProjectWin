   M S B A M L   `   `   `  ���� j  fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null-clr-namespace:StAbraam.ViewStAbraam.View  /clr-namespace:StAbraam.ModelStAbraam.Model       StAbraam.View.ServicesView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:StAbraam.View     .Modelclr-namespace:StAbraam.Model     -     � 	Resources     serviceViewSource  FirstCommand �� Text  LastCommand  NextCommand  PreviousCommand  DeleteServiceCommand  UpdateCommand  
AddCommand  CancelCommand��%�   &	        &	      &	      &	 &     &	 6     &	 J     &	 d     &	 v     &	 �     �� �� $ First���� $
 Last���� $
 Next���� $ Previous���� $ Delete Service���� $ Update���� $	 Add���� $ Cancel�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -	   # [ .���  � DataContext# [   � RowDefinitions �� $
��auto ��� $
��auto �.+���  �� Orientation$ 
Horizontal=�$��2,2,2,0q�$��36��$	��Top=�
�������# [  .+��� -
   $��btnFirst��$
��|◄��#��[ �� -   $��btnPrev��$	��◄��#��[ �� -   $��btnNext��$	��►��#��[ �� -   $��btnLast��$
��►|��#��[ �� -   $��	btnDelete��$��Delete Service��#��[ $��11(��� -   $��btnAdd��$��
New Servic��#��[ $��11(��� -   $��	btnUpdate��$��Commit��#��[ $��11(��� -   $��	btnCancel��$��Cancel��#��[ $��11(�� -    �Name$ existingServiceGrid��$��1��
���  ��# [  .+�&   System.Windows.Controls.DataGrid  -     Name$ serviceDataGrid��
���  ��	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�
   EnableRowVirtualization
 .    AutoGenerateColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   serviceIDColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader    Header$ 
Service ID��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	ServiceID+  -   serviceNameColumn��$ SizeToHeader $ Service Name�� .  �� *ServiceName+� -   $ newServiceGrid��$��1��
��� ���$y�	Collapsed=�# [  .+�  -   $ add_serviceDataGrid��
��� ���$	 VisibleWhenSelected=�
 .  .  ����    -   add_serviceIDColumn��$ SizeToHeader $ 
Service ID�� .  �� *	ServiceID+  -   add_serviceNameColumn��$ SizeToHeader $ Service Name�� �� *ServiceName+