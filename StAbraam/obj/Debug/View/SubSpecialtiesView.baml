   M S B A M L   `   `   `  ����j  fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null/clr-namespace:StAbraam.ModelStAbraam.Model  5      &     StAbraam.View.SubSpecialtiesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .Modelclr-namespace:StAbraam.Model     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � 	Resources  5
         sub_SpecialtyViewSource  specialtyViewSource  FirstCommand �� Text  LastCommand  NextCommand  PreviousCommand  DeleteSub_SpecialtyCommand  UpdateCommand  
AddCommand 	 CancelCommand��%�  &	        &	      &	 &     &	 E     &	 c     &	 �     &	 �     &	 �     &	 �     &		     �� 5   
   6   �� 5   
   6   �� 5   
   $ First��6/   �� 5   
   $
 Last��6.   �� 5   
   $
 Next��6.   �� 5   
   $ Previous��62   �� 5   
   $ Delete Sub-Specialty��6=   �� 5   
   $ Update��60   �� 5   
   $	 Add��6-   �� 5   
   $ Cancel��60   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6A     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6D     5   
   -   5        # [ 5      6O     5   
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
��►|��5<      �� 5=      -   5        $��	btnDelete��5>      #��[ 5?      $��Delete Sub-Specialty��5@      $��11(�5A      �� 5B      -   5        $��btnAdd��5C      #��[ 5D      $��Add or Edit Sub-Specialty��5E      $��11(�5F      �� 5G      -   5        $��	btnUpdate��5H      #��[ 5I      $��Commit��5J      $��11(�5K      �� 5L      -   5        $��	btnCancel��5M      #��[	 5N      $��Cancel��5O      $��11(�5P      5Q      � 5R   
   -   5         �Name$ existingSub_SpecialtyGrid��5S      $��1��5T      
���  ��# [  5V      .+�5W      &   System.Windows.Controls.DataGrid  -   5          Name$ sub_SpecialtyDataGrid��5X      	   AutoGenerateColumns	 .  
���  ��
   EnableRowVirtualization
 .    RowDetailsVisibilityMode$ VisibleWhenSelected=�5]      ��5\      ��    Columns 5^      0  *System.Windows.Controls.DataGridTextColumn  5_      -   5        sub_SpecialtyIDColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 5a         Header$ Sub Specialty ID��5c         
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5b      �� *Sub_SpecialtyID+5d        5e      -   5        sub_SpecialtyNameColumn��$ SizeToHeader 5g      $ Sub Specialty Name��5i       .  5h      �� *Sub_SpecialtyName+5j        5k      -   5        specialtyNameColumn��$ SizeToHeader 5m      $ Specialty Name��5o       .  5n      �� *Specialty.SpecialtyName+5p      5r      5s      � 5t   
   -   5        $ newSub_SpecialtyGrid��5u      $��1��5v      
��� ���# [  5x      $y�	Collapsed=�5y      .+�5z        -   5        $ add_sub_SpecialtyDataGrid��5{      	 .  
��� ���
 . $ VisibleWhenSelected=�5�      ��5      ��  5�        5�      -   5        add_sub_SpecialtyIDColumn��$ SizeToHeader 5�      $ Sub Specialty ID��5�       .  5�      �� *Sub_SpecialtyID+5�        5�      -   5        add_sub_SpecialtyNameColumn��$ SizeToHeader 5�      $ Sub Specialty Name��5�       5�      �� *Sub_SpecialtyName+5�      4  .System.Windows.Controls.DataGridComboBoxColumn  5�      -   5        add_specialtyNameColumn��$ SizeToHeader 5�         DisplayMemberPath$ SpecialtyName��5�      $ Specialty Name��5�         ItemsSource 5�      ��  �� Source# [    SelectedItemBinding 5�      �� *	Specialty+5�      5�      5�      5�      