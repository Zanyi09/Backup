   M S B A M L   `   `   `  ����G  CQuanlykhoWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:QuanlykhoWPF.ViewsQuanlykhoWPF.Views  5      #    QuanlykhoWPF.Views.UnitWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:QuanlykhoWPF.Views     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5         
  UnitVM  � DataContext#  [  5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��100 �6   �� 5      .+�5   
   � $��0��6    5      �� 5      6"   �� 5      $
��auto �6    60   .+�5      � $��0��6   
������ $��0,0,0,15q�69   .+�5      #  MaterialDesignThemes.Wpf.Card  $��0��6&   .��5      � .+�5      �� $	��600��6#   $��40 10 10 15q�6/   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Đơn vị đo��6�   $��13(�6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6D   �� *DisplayName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5      5        5       $��1��6"   
������ .��5!      � $��5q�6   $��Center=�6'   .+�5"      �  � ColumnDefinitions 5#      �� 5$      $	��150 �6/   6=   �� 5%      $	��150 �6/   6=   �� 5&      $	��150 �6/   6=   .+�5(      � $��0��6   $��10q�6/   .+�5)      �� $��2��6%   $��Thêm��5+   
   $��12(�5,   
   $��
Montserrat)�5-   
    � Cursor$
 Hand��5.   
   $��0q�5/   
   
�������$��Center=�51      ��5*   
   �� *
Addcommand+��52   "   �� 53   &    �� 
TargetType" ��6,   .�54   *   ��  �� Property � �� �� Value �#773DFF6G   �� 55   *    � �� 56   .   �� 57   2   	 �� 
TargetType"	 ��6B   .R�58   6   �� $��30��6=   
 �� CornerRadius$
 15��59   "   #��z��5:   "   ._�5;   :   �� $��Center=�6K   $��Center=�5<   4   5=   7   5>   3   5@   +    �� Triggers 5A   *   P� 5B   .    P� Property �@J�IsMouseOver P� Value . . �5C   2   ��  � �� �#836EFB6O   5D   /   5F   '   5H      5I      � 5J      $��1��6   $��10q�6/   .+�5K      �� $��2��6%   $��Sửa��5M      $��12(�5N      $��
Montserrat)�5O      $
 Hand��5P      $��0q�5Q      
�������$��Center=�5S      ��5L      �� *Editcommand+��5T   "   �� 5U   &   " ��6,   .�5V   *   ��  � �� �#773DFF6G   �� 5W   *    � �� 5X   .   �� 5Y   2   "	 ��6B   .R�5Z   6   �� $��30��6=   $
 15��5[   "   #��z��5\   "   ._�5]   :   �� $��Center=�6K   $��Center=�5^   4   5_   7   5`   3   5b   +    5c   *   P� 5d   .    �@J�IsMouseOver . . �5e   2   ��  � �� �#836EFB6O   5f   /   5h   '   5j      5k      � 5l      $��2��6   $��10q�6/   .+�5m      �� $��2��6%   $
��Xóa��5o      $��12(�5p      $��
Montserrat)�5q      $
 Hand��5r      $��0q�5s      
�������$��Center=�5u      ��5n      �� *Deletecommand+��5v   "   �� 5w   &   " ��6,   .�5x   *   ��  � �� �#773DFF6G   �� 5y   *    � �� 5z   .   �� 5{   2   "	 ��6B   .R�5|   6   �� $��30��6=   $
 15��5}   "   #��z��5~   "   ._�5   :   �� $��Center=�6K   $��Center=�5�   4   5�   7   5�   3   5�   +    5�   *   P� 5�   .    �@J�IsMouseOver . . �5�   2   ��  � �� �#836EFB6O   5�   /   5�   '   5�      5�      5�      5�      5�      5�      � 5�   
   $��1��6    5�      �� 5�      $
��auto �6#   �� 5�      $	��120 �6#   .+�5�      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5�      $��0��5�      .+�5�      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�6   $��20��6-   $��20��69     plainTextColor3   
Foreground# [ 6D   �� 5�      $��Search��6   $��13(�5�      $��24��5�      $	��300��5�      
������ $��Medium"�5�      $��
Montserrat)�5�      #��[ 5�       �� 
CaretBrush# [ 5�      #��[ 5�      $��0,0,0,1q�5�      $��Center=�5�      $��5,5,0,0q�5�      6*   5�      �� 5�      $��2��6   $��Search��5�      $��12(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��0q�5�      
�������$��Center=�5�      ��5�      �� *SearchCommand+��5�      �� 5�      " ��6   .�5�      ��  � �� �#773DFF67   �� 5�       � �� 5�      �� 5�   "   "	 ��62   .R�5�   &   �� $��30��6-   $
 15��5�   .   #��z��5�   .   ._�5�   *   �� $��Center=�6;   $��Center=�5�   @   5�   '   5�   #   5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   ��  � �� �#836EFB6?   5�      5�      5�      5�      �� 5�   
   $��2��6   ���#200F53$
 10��5�   
    �� Padding$ 10q�5�   
   ._�5�        $��2��6"   $��Stretch=�6/   .��5�      �� .��5�      �� ��6   �� *List+ �� SelectedItem 6<   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5�      �� 5�      .P�5�   "   �� $��ID��61    �� DisplayMemberBinding 6=   �� *Id+6c   �� 5�   "   $��Đơn vị đo��61    6D   �� *DisplayName+6s   5�      5�      5�      5�      5�      5�      5�      