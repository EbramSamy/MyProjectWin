   M S B A M L   `   `   `  ���� j  fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null-clr-namespace:StAbraam.ViewStAbraam.View  /clr-namespace:StAbraam.ModelStAbraam.Model      StAbraam.View.CitiesView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:StAbraam.View     .Modelclr-namespace:StAbraam.Model     -     � 	Resources     cityViewSource  countryViewSource  FirstCommand �� Text  LastCommand  NextCommand  PreviousCommand  DeleteCityCommand  UpdateCommand  
AddCommand 	 CancelCommand��%�   &	        &	      &	 
     &	      &	 +     &	 ;     &	 O     &	 f     &	 x     &		 �     �� �� �� $ First���� $
 Last���� $
 Next���� $ Previous���� $ Delete City���� $ Update���� $	 Add���� $ Cancel�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -	   # [	 .���  � DataContext# [   � RowDefinitions �� $
��auto ��� $
��auto �.+���  �� Orientation$ 
Horizontal=�$��2,2,2,0q�$��36��$	��Top=�
�������# [  .+��� -
   $��btnFirst��$
��|◄��#��[ �� -   $��btnPrev��$	��◄��#��[ �� -   $��btnNext��$	��►��#��[ �� -   $��btnLast��$
��►|��#��[ �� -   $��	btnDelete��$��Delete City��#��[ $��11(��� -   $��btnAdd��$��Add or Edit City��#��[ $��11(��� -   $��	btnUpdate��$��Commit��#��[ $��11(��� -   $��	btnCancel��$��Cancel��#��[	 $��11(�� -    �Name$ existingCityGrid��$��1��
���  ��# [  .+�&   System.Windows.Controls.DataGrid  -     Name$ cityDataGrid��
���  ��	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�
   EnableRowVirtualization
 .    AutoGenerateColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   cityIDColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader    Header$ City ID��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *CityID+  -   cityNameColumn��$ SizeToHeader $ 	City Name�� .  �� *
CityName+  -   countryIDColumn��$ SizeToHeader $ Country Name�� .  �� *Country.CountryName+� -   $ newCityGrid��$��1��
��� ���$y�	Collapsed=�# [  .+�  
��� ���$	 VisibleWhenSelected=�
 .  .  ����    -   add_cityIDColumn��$ SizeToHeader $ City ID�� .  �� *CityID+  -   add_cityNameColumn��$ SizeToHeader $ 	City Name�� �� *
CityName+4  .System.Windows.Controls.DataGridComboBoxColumn  -   add_countryIDColumn��   DisplayMemberPath$ CountryName��$ SizeToHeader $ Country Name��   ItemsSource ��  �� Source# [    SelectedItemBinding �� *	Country+