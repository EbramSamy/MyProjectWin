   M S B A M L   `   `   `  ����j  fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null/clr-namespace:StAbraam.ModelStAbraam.Model  5      !    StAbraam.View.LanguagesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .Modelclr-namespace:StAbraam.Model     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � 	Resources  5         languageViewSource  FirstCommand �� Text  LastCommand  NextCommand  PreviousCommand  DeleteLanguageCommand  UpdateCommand  
AddCommand  CancelCommand��%p  &	        &	      &	 2     &	 P     &	 n     &	 �     &	 �     &	 �     &	 �     �� 5   
   6   �� 5   
   $ First��6/   �� 5   
   $
 Last��6.   �� 5   
   $
 Next��6.   �� 5   
   $ Previous��62   �� 5   
   $ Delete Language��68   �� 5   
   $ Update��60   �� 5   
   $	 Add��6-   �� 5   
   $ Cancel��60   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6A     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6D     5   
   -   5        # [ 5      6J     5   
   -   5        # [ 5      6B     5   
   -   5        # [ 5      6?     5    
   -	   5        # [ 5       6B   .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��auto �6   �� 5%      $
��auto �6   �� 5&      $��* �6   .+�5(   
   �� $��36��5)      $��2,2,2,0q�5*      $	��Top=�5+      
������� � DataContext# [  5-       �� Orientation$ 
Horizontal=�5.      .+�50      �� -
   5        $��btnFirst��51      #��[ 52      $
��|◄��53      �� 54      -   5        $��btnPrev��55      #��[ 56      $	��◄��57      �� 58      -   5        $��btnNext��59      #��[ 5:      $	��►��5;      �� 5<      -   5        $��btnLast��5=      #��[ 5>      $
��►|��5?      �� 5@      -   5        $��	btnDelete��5A      #��[ 5B      $��Delete Language��5C      $��11(�5D      �� 5E      -   5        $��btnAdd��5F      #��[ 5G      $��New Language��5H      $��11(�5I      �� 5J      -   5        $��	btnUpdate��5K      #��[ 5L      $��Commit��5M      $��11(�5N      �� 5O      -   5        $��	btnCancel��5P      #��[ 5Q      $��Cancel��5R      $��11(�5S      5T      � 5V   
   -   5         �Name$ existingLanguageGrid��5W      $��1��5X      
���  ��# [  5Z      .+�5[      &   System.Windows.Controls.DataGrid  -   5          Name$ existinglanguageDataGrid��5\      	   AutoGenerateColumns	 .  
���  ��
   EnableRowVirtualization
 .    RowDetailsVisibilityMode$ VisibleWhenSelected=�5a      ��5`      ��    Columns 5b      0  *System.Windows.Controls.DataGridTextColumn  5c      -   5        languagIDColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 5e         Header$ 
Languag ID��5g         
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5f      �� *	LanguagID+5h        5i      -   5        languageNameColumn��$ SizeToHeader 5k      $ Language Name��5m       .  5l      �� *LanguageName+5n      5p      5q      � 5t   
   -   5        $ newLanguageGrid��5u      $��1��5v      
��� ���# [  5x      $y�	Collapsed=�5y      .+�5z        	 .  
��� ���
 . $ VisibleWhenSelected=�5      ��5~      ��  5�        5�      -   5        add_languagIDColumn��$ SizeToHeader 5�      $ 
Languag ID��5�       .  5�      �� *	LanguagID+5�        5�      -   5        add_languageNameColumn��$ SizeToHeader 5�      $ Language Name��5�       5�      �� *LanguageName+5�      5�      5�      5�      5�      