   M S B A M L   `   `   `  ����j  fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null/clr-namespace:StAbraam.ModelStAbraam.Model  5           StAbraam.View.ServicesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .Modelclr-namespace:StAbraam.Model     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � 	Resources  5
         serviceViewSource  FirstCommand �� Text  LastCommand  NextCommand  PreviousCommand  DeleteServiceCommand  UpdateCommand  
AddCommand  CancelCommand��%o  &	        &	      &	 2     &	 P     &	 n     &	 �     &	 �     &	 �     &	 �     �� 5   
   6   �� 5   
   $ First��6/   �� 5   
   $
 Last��6.   �� 5   
   $
 Next��6.   �� 5   
   $ Previous��62   �� 5   
   $ Delete Service��67   �� 5   
   $ Update��60   �� 5   
   $	 Add��6-   �� 5   
   $ Cancel��60   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6A     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6D     5   
   -   5        # [ 5      6I     5   
   -   5        # [ 5      6B     5   
   -   5        # [ 5      6?     5   
   -	   5        # [ 5      6B   .��5       �  � DataContext# [  6    � RowDefinitions 5!   
   �� 5"      $
��auto �6   �� 5#      $
��auto �6   .+�5&   
   �� $��36��5'      $��2,2,2,0q�5(      $	��Top=�5)      
�������# [  5+       �� Orientation$ 
Horizontal=�5,      .+�5.      �� -
   5        $��btnFirst��5/      #��[ 50      $
��|◄��51      �� 52      -   5        $��btnPrev��53      #��[ 54      $	��◄��55      �� 56      -   5        $��btnNext��57      #��[ 58      $	��►��59      �� 5:      -   5        $��btnLast��5;      #��[ 5<      $
��►|��5=      �� 5>      -   5        $��	btnDelete��5?      #��[ 5@      $��Delete Service��5A      $��11(�5B      �� 5C      -   5        $��btnAdd��5D      #��[ 5E      $��
New Servic��5F      $��11(�5G      �� 5H      -   5        $��	btnUpdate��5I      #��[ 5J      $��Commit��5K      $��11(�5L      �� 5M      -   5        $��	btnCancel��5N      #��[ 5O      $��Cancel��5P      $��11(�5Q      5R      � 5U   
   -   5         �Name$ existingServiceGrid��5V      $��1��5W      
���  ��# [  5Y      .+�5Z      &   System.Windows.Controls.DataGrid  -   5          Name$ serviceDataGrid��5[      	   AutoGenerateColumns	 .  
���  ��
   EnableRowVirtualization
 .    RowDetailsVisibilityMode$ VisibleWhenSelected=�5`      ��5_      ��    Columns 5a      0  *System.Windows.Controls.DataGridTextColumn  5b      -   5        serviceIDColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 5d         Header$ 
Service ID��5f         
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5e      �� *	ServiceID+5g        5h      -   5        serviceNameColumn��$ SizeToHeader 5j      $ Service Name��5l       .  5k      �� *ServiceName+5m      5o      5p      � 5r   
   -   5        $ newServiceGrid��5s      $��1��5t      
��� ���# [  5v      $y�	Collapsed=�5w      .+�5x        -   5        $ add_serviceDataGrid��5y      	 .  
��� ���
 . $ VisibleWhenSelected=�5~      ��5}      ��  5        5�      -   5        add_serviceIDColumn��$ SizeToHeader 5�      $ 
Service ID��5�       .  5�      �� *	ServiceID+5�        5�      -   5        add_serviceNameColumn��$ SizeToHeader 5�      $ Service Name��5�       5�      �� *ServiceName+5�      5�      5�      5�      5�      