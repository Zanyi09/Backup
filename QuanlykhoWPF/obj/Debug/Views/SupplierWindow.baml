   M S B A M L   `   `   `  ����G  CQuanlykhoWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:QuanlykhoWPF.ViewsQuanlykhoWPF.Views  5      '    !QuanlykhoWPF.Views.SupplierWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:QuanlykhoWPF.Views     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         
SupplierVM  � DataContext#  [  5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��100 �6   �� 5      .+�5   
   � $��0��6    5      �� 5      6"   �� 5      $
��auto �6    60   .+�5      � $��0��6   
������ $��0,0,0,15q�69   .+�5      #  MaterialDesignThemes.Wpf.Card  $��0��6&   .��5      � .+�5      �� $��40 10 10 15q�6#   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhà cung cấp��6z   $��13(�6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��68   �� *DisplayName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��55 10 10 15q�6#   $ Địa chỉ��6v   $��13(�6�   #��[ 6�   ��68   �� *	Address+$ PropertyChanged=�6�   �� 5      $��55 10 10 15q�6#   $ Email��6t   $��13(�6�   #��[ 6�   ��68   �� *Email+$ PropertyChanged=�6�   �� 5      $��55 10 10 15q�6#   $ Điện thoại��6t   $��13(�6�   #��[ 6�   ��68   �� *Phone+$ PropertyChanged=�6�   �� 5      $��55 10 10 15q�6#   $ Thông tin thêm��6w   $��13(�6�   #��[ 6�   ��68   �� *
Moreinfo+$ PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  5      $��Center=�6&   $��55 10 10 15q�6C   $	��180��5       $ 	Pick Date��5!      $��13(�6<   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  ( $MaterialDesignFloatingHintDatePicker#��[ 5#         SelectedDate 5   X   �� *ContractDate+$ PropertyChanged=�5#      5$      5%      5&        5'      $��1��6"   
������ .��5(      � $��5q�6   $��Center=�6'   .+�5)      �  � ColumnDefinitions 5*      �� 5+      $	��150 �6/   6=   �� 5,      $	��150 �6/   6=   �� 5-      $	��150 �6/   6=   .+�5/      � $��0��6   $��10q�6/   .+�50      �� $��2��6%   $��Thêm��52      $��12(�53      $��
Montserrat)�54       � Cursor$
 Hand��55      $��0q�56      
�������$��Center=�58      ��51      �� *
Addcommand+��59   "   �� 5:   &    �� 
TargetType" ��6,   .�5;   *   �� 	 �� Property	 � ��
 �� Value
 �#773DFF6G   �� 5<   *   	 � ��
 5=   .   �� 5>   2    �� 
TargetType" ��6B   .R�5?   6   �� $��30��6=    �� CornerRadius$ 15��5@   %   #��z��5A   %   ._�5B   :   �� $��Center=�6K   $��Center=�5C   7   5D   7   5E   3   5G   +    �� Triggers 5H   *   P� 5I   .    P� Property �@J�IsMouseOver P� Value . . �5J   2   �� 	 � ��
 �#836EFB6O   5K   /   5M   '   5O      5P      � 5Q      $��1��6   $��10q�6/   .+�5R      �� $��2��6%   $��Sửa��5T      $��12(�5U      $��
Montserrat)�5V      $
 Hand��5W      $��0q�5X      
�������$��Center=�5Z      ��5S      �� *Editcommand+��5[   "   �� 5\   &   " ��6,   .�5]   *   �� 	 � ��
 �#773DFF6G   �� 5^   *   	 � ��
 5_   .   �� 5`   2   " ��6B   .R�5a   6   �� $��30��6=   $ 15��5b   %   #��z��5c   %   ._�5d   :   �� $��Center=�6K   $��Center=�5e   7   5f   7   5g   3   5i   +    5j   *   P� 5k   .    �@J�IsMouseOver . . �5l   2   �� 	 � ��
 �#836EFB6O   5m   /   5o   '   5q      5r      � 5s      $��2��6   $��10q�6/   .+�5t      �� $��2��6%   $
��Xóa��5v      $��12(�5w      $��
Montserrat)�5x      $
 Hand��5y      $��0q�5z      
�������$��Center=�5|      ��5u      �� *DeleteCommand+��5}   "   �� 5~   &   " ��6,   .�5   *   �� 	 � ��
 �#773DFF6G   �� 5�   *   	 � ��
 5�   .   �� 5�   2   " ��6B   .R�5�   6   �� $��30��6=   $ 15��5�   %   #��z��5�   %   ._�5�   :   �� $��Center=�6K   $��Center=�5�   7   5�   7   5�   3   5�   +    5�   *   P� 5�   .    �@J�IsMouseOver . . �5�   2   �� 	 � ��
 �#836EFB6O   5�   /   5�   '   5�      5�      5�      5�      5�      5�      � 5�   
   $��1��6    5�      �� 5�      $
��auto �6#   �� 5�      $	��120 �6#   .+�5�      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5�      $��0��5�      .+�5�      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�6   $��20��6-   $��20��69     plainTextColor3   
Foreground# [ 6D   �� 5�      $��Search��6   $��13(�5�      $��24��5�      $	��300��5�      
������ $��Medium"�5�      $��
Montserrat)�5�      #��[ 5�       �� 
CaretBrush# [ 5�      #��[ 5�      $��0,0,0,1q�5�      $��Center=�5�      $��5,5,0,0q�5�      6-   5�      �� 5�      $��2��6   $��Search��5�      $��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��0q�5�      
�������$��Center=�5�      ��5�      �� *SearchCommand+��5�      �� 5�      " ��6   .�5�      �� 	 � ��
 �#773DFF67   �� 5�      	 � ��
 5�      �� 5�   "   " ��62   .R�5�   &   �� $��30��6-   $ 15��5�   1   #��z��5�   1   ._�5�   *   �� $��Center=�6;   $��Center=�5�   C   5�   '   5�   #   5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� 	 � ��
 �#836EFB6?   5�      5�      5�      5�      �� 5�   
   $��2��6   ���#200F53$ 10��5�       �� Padding$ 10q�5�      ._�5�        $��2��6"   $��Stretch=�6/   .��5�      �� .��5�      �� ��6   �� *List+ �� SelectedItem 6<   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5�      �� 5�      .P�5�   "   �� $��Nhà cung cấp��61    �� DisplayMemberBinding 6G   �� *DisplayName+6v   �� 5�   "   $��Địa chỉ��61    6B   �� *	Address+6m   �� 5�   "   $��Email��61    6@   �� *Email+6i   �� 5�   "   $��Điện thoại��61    6E   �� *Phone+6n   �� 5�   "   $��Thông tin thêm��61    6I   �� *
MoreInfo+6u   �� 5�   "   $��Ngày hợp tác��61    6G   �� *ContractDate+6w   5�      5�      5�      5�      5�      5�      5�      