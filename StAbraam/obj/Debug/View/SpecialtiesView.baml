   M S B A M L   `   `   `  ����j  fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null/clr-namespace:StAbraam.ModelStAbraam.Model  5      #    StAbraam.View.SpecialtiesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .Modelclr-namespace:StAbraam.Model     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � 	Resources  5         specialtyViewSource  FirstCommand �� Text  LastCommand  NextCommand  PreviousCommand  DeleteSpecialtyCommand  UpdateCommand  
AddCommand  CancelCommand��%q  &	        &	      &	 2     &	 P     &	 n     &	 �     &	 �     &	 �     &	 �     �� 5   
   6   �� 5   
   $ First��6/   �� 5   
   $
 Last��6.   �� 5   
   $
 Next��6.   �� 5   
   $ Previous��62   �� 5   
   $ Delete Specialty��69   �� 5   
   $ Update��60   �� 5   
   $	 Add��6-   �� 5   
   $ Cancel��60   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6A     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6D     5   
   -   5        # [ 5      6K     5   
   -   5        # [ 5      6B     5   
   -   5        # [ 5      6?     5   
   -	   5        # [ 5      6B   .��5!      �  � DataContext# [  6    � RowDefinitions 5"   
   �� 5#      $
��auto �6   �� 5$      $
��auto �6   �� 5%      $��* �6   .+�5'   
   �� $��36��5(      $	��Top=�5)      
�������# [  5+       �� Orientation$ 
Horizontal=�5,      .+�5.      �� -
   5        $��btnFirst��5/      #��[ 50      $
��|◄��51      �� 52      -   5        $��btnPrev��53      #��[ 54      $	��◄��55      �� 56      -   5        $��btnNext��57      #��[ 58      $	��►��59      �� 5:      -   5        $��btnLast��5;      #��[ 5<      $
��►|��5=      �� 5>      -   5        $��btnAdd��5?      $	��120��5@      $��Add Specialty��5B      $��11(�5C      �� 5D      -   5        $��	btnDelete��5E      #��[ 5F      $��Delete Specialty��5G      $��11(�5H      �� 5I      -   5        $��btnEdit��5J      #��[ 5K      $��Edit Specialty��5L      $��11(�5M      �� 5N      -   5        $��	btnUpdate��5O      #��[ 5P      $��Commit��5Q      $��11(�5R      �� 5S      -   5        $��	btnCancel��5T      #��[ 5U      $��Cancel��5V      $��11(�5W      5X      � 5Z   
   -   5         �Name$ existingSpecialtyGrid��5[      $��1��5\      $��Stretch=�5]      $��Stretch=�5^      
���  ��# [  5`      .+�5a      �� -   5         ��Name$ specialtyListView��5b      	 �� SelectionMode$	 Single=�5d      ��5c      �� 
 �� View
 5e      �� 5f      .P�5g      �� -   5        specialtyIDColumn�� �� Width$ 80��5i      $��Specialty ID��5j       �� CellTemplate 5k      �� 5l   "   .R�5m   &   �� ��60   �� *SpecialtyID+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 5n   #   5p      �� 5q      -   5        specialtyNameColumn��$ 80��5s      $��Specialty Name��5t       5u      �� 5v   "   .R�5w   &   �� ��60   �� *SpecialtyName+$ TwoWay=� .  . 5x   #   5z      �� 5|      $��  Sub-Specialty ��6)    5}      �� 5~   "   .R�5   &   �� ��63   �� *Sub_Specialty+��5�   *   �� 5�   .   .R�5�   2   �� $ Vertical=�6=   5�   /   ��5�   *   �� 5�   .   .R�5�   2   �� $ 
Horizontal=�6=   .+�5�   6   �� $��2q�6@   ��6K   �� *Sub_SpecialtyID+$ TwoWay=� .  . �� 5�   6   $��2q�6@   ��6K   �� *Sub_SpecialtyName+$ TwoWay=� .  . 5�   3   5�   /   5�   '   5�   #   5�      5�      5�      5�      � 5�   
   -   5        $ newSpecialtyGrid��5�      $��1��5�      $��Stretch=�5�      $��Stretch=�5�      
��� ���$y�	Collapsed=�5�      .+�5�      �� -   5        $ add_specialtyListView��5�      $	 Single=�5�      ��5�      �� 
 5�      �� 5�      .P�5�      �� -   5        add_specialtyIDColumn��$ 80��5�      $��Specialty ID��5�       5�      �� 5�   "   .R�5�   &   �� ���	#FF7CB7D1��6E   �� *SpecialtyID+$ TwoWay=� .  . 5�   #   5�      �� 5�      -   5        add_specialtyNameColumn��$ 80��5�      $��Specialty Name��5�       5�      �� 5�   "   .R�5�   &   �� ���	#FF7CB7D1��6E   �� *SpecialtyName+$ TwoWay=� .  . 5�   #   5�      �� 5�      $��  Sub-Specialty ��6)    5�      �� 5�   "   .R�5�   &   �� ��63   �� *Sub_Specialty+��5�   *   �� 5�   .   .R�5�   2   �� $ Vertical=�6=   5�   /   ��5�   *   �� 5�   .   .R�5�   2   �� $ 
Horizontal=�6=   .+�5�   6   �� $��2q�5�   9   ���	#FF7CB7D1��5�   9   �� *Sub_SpecialtyID+$ TwoWay=� .  . �� 5�   6   $��2q�5�   9   ���	#FF7CB7D1��5�   9   �� *Sub_SpecialtyName+$ TwoWay=� .  . 5�   3   5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      5�      