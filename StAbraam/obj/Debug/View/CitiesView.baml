   M S B A M L   `   `   `  ����j  fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null/clr-namespace:StAbraam.ModelStAbraam.Model  5          StAbraam.View.CitiesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .Modelclr-namespace:StAbraam.Model     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � 	Resources  5
         cityViewSource  countryViewSource  FirstCommand �� Text  LastCommand  NextCommand  PreviousCommand  DeleteCityCommand  UpdateCommand  
AddCommand 	 CancelCommand��%�  &	        &	      &	 &     &	 E     &	 c     &	 �     &	 �     &	 �     &	 �     &		     �� 5   
   6   �� 5   
   6   �� 5   
   $ First��6/   �� 5   
   $
 Last��6.   �� 5   
   $
 Next��6.   �� 5   
   $ Previous��62   �� 5   
   $ Delete City��64   �� 5   
   $ Update��60   �� 5   
   $	 Add��6-   �� 5   
   $ Cancel��60   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6A     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6D     5   
   -   5        # [ 5      6F     5   
   -   5        # [ 5      6B     5   
   -   5        # [ 5      6?     5   
   -	   5        # [	 5      6B   .��5       �  � DataContext# [  6    � RowDefinitions 5!   
   �� 5"      $
��auto �6   �� 5#      $
��auto �6   .+�5%   
   �� $��36��5&      $��2,2,2,0q�5'      $	��Top=�5(      
�������# [  5*       �� Orientation$ 
Horizontal=�5+      .+�5-      �� -
   5        $��btnFirst��5.      #��[ 5/      $
��|◄��50      �� 51      -   5        $��btnPrev��52      #��[ 53      $	��◄��54      �� 55      -   5        $��btnNext��56      #��[ 57      $	��►��58      �� 59      -   5        $��btnLast��5:      #��[ 5;      $
��►|��5<      �� 5=      -   5        $��	btnDelete��5>      #��[ 5?      $��Delete City��5@      $��11(�5A      �� 5B      -   5        $��btnAdd��5C      #��[ 5D      $��Add or Edit City��5E      $��11(�5F      �� 5G      -   5        $��	btnUpdate��5H      #��[ 5I      $��Commit��5J      $��11(�5K      �� 5L      -   5        $��	btnCancel��5M      #��[	 5N      $��Cancel��5O      $��11(�5P      5Q      � 5R   
   -   5         �Name$ existingCityGrid��5S      $��1��5T      
���  ��# [  5V      .+�5W      &   System.Windows.Controls.DataGrid  -   5          Name$ cityDataGrid��5X      	   AutoGenerateColumns	 .  
���  ��
   EnableRowVirtualization
 .    RowDetailsVisibilityMode$ VisibleWhenSelected=�5]      ��5\      ��    Columns 5^      0  *System.Windows.Controls.DataGridTextColumn  5_      -   5        cityIDColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 5a         Header$ City ID��5c         
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5b      �� *CityID+5d        5e      -   5        cityNameColumn��$ SizeToHeader 5g      $ 	City Name��5i       .  5h      �� *
CityName+5j        5k      -   5        countryIDColumn��$ SizeToHeader 5m      $ Country Name��5o       .  5n      �� *Country.CountryName+5p      5r      5s      � 5u   
   -   5        $ newCityGrid��5v      $��1��5w      
��� ���# [  5y      $y�	Collapsed=�5z      .+�5{        	 .  
��� ���
 . $ VisibleWhenSelected=�5�      ��5      ��  5�        5�      -   5        add_cityIDColumn��$ SizeToHeader 5�      $ City ID��5�       .  5�      �� *CityID+5�        5�      -   5        add_cityNameColumn��$ SizeToHeader 5�      $ 	City Name��5�       5�      �� *
CityName+5�      4  .System.Windows.Controls.DataGridComboBoxColumn  5�      -   5        add_countryIDColumn��$ SizeToHeader 5�         DisplayMemberPath$ CountryName��5�      $ Country Name��5�         ItemsSource 5�      ��  �� Source# [    SelectedItemBinding 5�      �� *	Country+5�      5�      5�      5�      