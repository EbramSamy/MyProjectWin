   M S B A M L   `   `   `  ���� j  fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null/clr-namespace:StAbraam.ModelStAbraam.Model  !    StAbraam.View.CountriesView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .Modelclr-namespace:StAbraam.Model     -     � 	Resources     countryViewSource  FirstCommand �� Text  LastCommand  NextCommand  PreviousCommand  DeleteCounryCommand  UpdateCommand  
AddCommand  CancelCommand��%�   &	        &	      &	      &	 &     &	 6     &	 J     &	 d     &	 v     &	 �     �� �� $ First���� $
 Last���� $
 Next���� $ Previous���� $ Delete Country���� $ Update���� $	 Add���� $ Cancel�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -	   # [ .���  � DataContext# [   � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+���  �� Orientation$ 
Horizontal=�$��36��$	��Top=�
�������# [  .+��� -
   $��btnFirst��$
��|◄��#��[ �� -   $��btnPrev��$	��◄��#��[ �� -   $��btnNext��$	��►��#��[ �� -   $��btnLast��$
��►|��#��[ �� -   $��btnAdd��$��Add Country��$��11(�$	��120���� -   $��	btnDelete��$��Delete Country��#��[ $��11(��� -   $��btnEdit��$��Edit Country��#��[ $��11(��� -   $��	btnUpdate��$��Commit��#��[ $��11(��� -   $��	btnCancel��$��Cancel��#��[ $��11(�� -    �Name$ existingCountryGrid��$��1��$��Stretch=�$��Stretch=�
���  ��# [  .+��� -    ��Name$ countryListView��	 �� SelectionMode$	 Single=����� 
 �� View
 �� .P��� -   countryIDColumn��$��
Country ID�� �� CellTemplate �� .R��� $��Center=����� *	CountryID+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . �� -   countryNameColumn��$��Country Name�� �� .R��� $��Center=����� *CountryName+$ TwoWay=� .  . �� $��	  Cities �� �� .R��� ���� *Cities+���� .R��� $ Vertical=����� .R��� $ 
Horizontal=�.+��� $��2q����� *CityID+$ TwoWay=� .  . �� $��2q����� *
CityName+$ TwoWay=� .  . � -   $ newCountryGrid��$��1��
��� ���$��Stretch=�$��Stretch=�$y�	Collapsed=�.+��� -   $ newcountryListView��$	 Single=����� 
 �� .P��� -   newCountryIDColumn��$��
Country ID�� �� .R��� ���	#FF7CB7D1$��Center=����� *	CountryID+$ TwoWay=� .  . �� -   newCountryNameColumn��$��Country Name�� �� .R��� $��add_country_name_textBox�����	#FF7CB7D1$��Center=����� *CountryName+$ TwoWay=� .  . �� $��	  Cities �� �� .R��� ���� *Cities+���� .R��� $ Vertical=����� .R��� $ 
Horizontal=�.+��� ���	#FF7CB7D1���� *CityID+$ TwoWay=� .  . ��  ��Name$ newCityNameColumn�����	#FF7CB7D1���� *
CityName+$ TwoWay=� .  . 