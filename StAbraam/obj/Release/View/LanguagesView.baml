   M S B A M L   `   `   `  ���� j  fخدمة الانباء ابرام الطبية, Version=0.0.0.7, Culture=neutral, PublicKeyToken=null-clr-namespace:StAbraam.ViewStAbraam.View  /clr-namespace:StAbraam.ModelStAbraam.Model  !    StAbraam.View.LanguagesView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:StAbraam.View     .Modelclr-namespace:StAbraam.Model     -     � 	Resources     languageViewSource  FirstCommand �� Text  LastCommand  NextCommand  PreviousCommand  DeleteLanguageCommand  UpdateCommand  
AddCommand  CancelCommand��%�   &	        &	      &	      &	 &     &	 6     &	 J     &	 e     &	 w     &	 �     �� �� $ First���� $
 Last���� $
 Next���� $ Previous���� $ Delete Language���� $ Update���� $	 Add���� $ Cancel�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -	   # [ .���  � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+���  �� Orientation$ 
Horizontal=�$��2,2,2,0q�$��36��$	��Top=�
������� � DataContext# [  .+��� -
   $��btnFirst��$
��|◄��#��[ �� -   $��btnPrev��$	��◄��#��[ �� -   $��btnNext��$	��►��#��[ �� -   $��btnLast��$
��►|��#��[ �� -   $��	btnDelete��$��Delete Language��#��[ $��11(��� -   $��btnAdd��$��New Language��#��[ $��11(��� -   $��	btnUpdate��$��Commit��#��[ $��11(��� -   $��	btnCancel��$��Cancel��#��[ $��11(�� -    �Name$ existingLanguageGrid��$��1��
���  ��# [  .+�&   System.Windows.Controls.DataGrid  -     Name$ existinglanguageDataGrid��
���  ��	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�
   EnableRowVirtualization
 .    AutoGenerateColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   languagIDColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader    Header$ 
Languag ID��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	LanguagID+  -   languageNameColumn��$ SizeToHeader $ Language Name�� .  �� *LanguageName+� -   $ newLanguageGrid��$��1��
��� ���$y�	Collapsed=�# [  .+�  
��� ���$	 VisibleWhenSelected=�
 .  .  ����    -   add_languagIDColumn��$ SizeToHeader $ 
Languag ID�� .  �� *	LanguagID+  -   add_languageNameColumn��$ SizeToHeader $ Language Name�� �� *LanguageName+