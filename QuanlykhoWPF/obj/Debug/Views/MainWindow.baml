   M S B A M L   `   `   `  ����G  CQuanlykhoWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanlykhoWPFQuanlykhoWPF  5   	   ?$clr-namespace:QuanlykhoWPF.ViewModelQuanlykhoWPF.ViewModel  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   7 clr-namespace:QuanlykhoWPF.ViewsQuanlykhoWPF.Views  6<       QuanlykhoWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanlykhoWPF     5   	   X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   -uc$clr-namespace:QuanlykhoWPF.ViewModel  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -local1 clr-namespace:QuanlykhoWPF.Views  6<   -   5        $��
mainWindow��5   
      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   
   
������  � AllowsTransparency .   MaterialDesignFont#���  5   	    
 MainVM � DataContext# [ 5   	    � Title$! HỆ THỐNG QUẢN LÝ KHO��5   	   $	��800��6&   $
��1300��63   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
   	   	EventName$	 Loaded��6   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5       6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *WindowLoaded+   CommandParameter 5!   !   ��  �� ElementName$ 
mainWindow��5"       � 	Resources 5$       �� DataType.   (QuanlykhoWPF.ViewModel.CustomerViewModel'   !QuanlykhoWPF.Views.CustomerWindow.   (QuanlykhoWPF.ViewModel.SupplierViewModel'	   !QuanlykhoWPF.Views.SupplierWindow*
   $QuanlykhoWPF.ViewModel.UnitViewModel#   QuanlykhoWPF.Views.UnitWindow*   $QuanlykhoWPF.ViewModel.MainViewModel%   QuanlykhoWPF.Views.ObjectWindow+   %QuanlykhoWPF.ViewModel.StaffViewModel$   QuanlykhoWPF.Views.StaffWindow+   %QuanlykhoWPF.ViewModel.InputViewModel$   QuanlykhoWPF.Views.InputWindow,   &QuanlykhoWPF.ViewModel.ReportViewModel%   QuanlykhoWPF.Views.ReportWindow,   &QuanlykhoWPF.ViewModel.OutputViewModel%   QuanlykhoWPF.Views.OutputWindow��%X  (��       5%      *, +)(�� 2     5(      *, +)(�� d     5+      *,
 +)(�� �     5.      *, +)(�� �     51      *, +)(�� �     54      *, +)(�� ,    57      *, +)(�� ^    5:      *, +)�� 5%   
   "  6   .R�5&        5'      �� 5(   
   "  6   .R�5)      	  5*      �� 5+   
   " 
 6   .R�5,        5-      �� 5.   
   "  6   .R�5/        50      �� 51   
   "  6   .R�52        53      �� 54   
   "  6   .R�55        56      �� 57   
   "  6   .R�58        59      �� 5:   
   "  6   .R�5;        5<      5=      .��5>      ��  �� CornerRadius$ 10��6   $��1q�5?      ��5@   
   �� 5A       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5B      �   winBorderColor1 � Color# [ 6    � Offset$ 0Q�6H   � 5C        winBorderColor2# [ 6   $	 0.5Q�6H   � 5D        winBorderColor3# [ 6   $ 1Q�6H   5E      ._�5G   
   �  � ColumnDefinitions 5H      �� 5J      $	��250 �6#   61   �� 5L      $��* �6#   6/   .+�5O      �� $ 	10,0,0,10��6   $��0��5P      ��5Q      �� 5R      $	 0,0&�6*   $ 1,0.7&�6;   .��5S      �   secondaryBackColor1# [ 6'   $ 0Q�6T   � 5T        secondaryBackColor2# [ 6'   $ 1Q�6T   5U      ._�5W      �� .+�5Y      ��  �� Orientation$ 
Horizontal=�6!   $��35��5Z   !   $��
15,25,0,40q�5[   !   .+�5\      �� $��/Images/Logo.png��6    $��30��6:   �� 5]      $��SYSTEM IRTECH��6$     titleColor2#��[ 5^   $   $��20(�5_   $   $��
Montserrat)�5`   $   $��Medium"�5a   $   $��Center=�5b   $   $��10,0,0,0q�5c   $   5e      	� 5g       	 
menuButton#��[	 6"    

 color1
 � Tag# [
 5h   "    d� 	IsChecked$
 TrueY�5i   "   ��5j   "   �� *ShowHomeViewCommand+.��5k      �� $ 
Horizontal=�6%   .+�5l      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6+     menuButtonIcon#��[ 67   �� 5m      $��Trang chủ��6(     menuButtonText#��[ 69   5n      5o      	� 5p      #��[	 6"    
 color2# [ 5q   "   ��5r   "   �� *ShowHomeCustomer+.��5s      �� $ 
Horizontal=�6%   .+�5t        $ 	UserGroup=�6+   #��[ 6<   �� 5u      $��Khách hàng��6(   #��[ 6:   5v      5w      	� 5x      #��[	 6"   # [ 5y   !   ��5z   "   �� *ShowHomeUnit+.��5{      �� $ 
Horizontal=�6%   .+�5|        $ K=�6+   #��[ 64   �� 5}      $��Đơn vị đo��6(   #��[ 69   5~      5      	� 5�      #��[	 6"    
 color3# [ 5�   "   ��5�   "   �� *ShowHomeSupplier+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ BoxOpen=�6+   #��[ 6:   �� 5�      $��Nhà cung cấp��6(   #��[ 6<   5�      5�      	� 5�      #��[	 6"    
 color6# [ 5�   !   ��5�   !   �� *ShowHomeObject+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ Truck=�6+   #��[ 68   �� 5�      $��	Vật tư��6(   #��[ 66   5�      5�      	� 5�      #��[	 6"    
 color4# [ 5�   !   ��5�   !   �� *ShowHomeInput+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ ArrowAltCircleDown=�6+   #��[ 6E   �� 5�      $��Nhập hàng��6(   #��[ 69   5�      5�      	� 5�      #��[	 6"    
 color5# [ 5�   "   ��5�   "   �� *ShowHomeOuput+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ ArrowAltCircleUp=�6+   #��[ 6C   �� 5�      $��Xuất hàng��6(   #��[ 69   5�      5�      	� 5�      #��[	 6"    
 color7# [ 5�   !   ��5�   !   �� *ShowHomeReport+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ PieChart=�6+   #��[ 6;   �� 5�      $��	Báo cáo��6(   #��[ 67   5�      5�      	� 5�      #��[	 6"    
 color9# [ 5�   !   ��5�   !   �� *ShowCustomerViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ Tools=�6+   #��[ 68   �� 5�      $��Cài đặt��6(   #��[ 67   5�      5�      5�      5�      �� 5�      $ 	0,10,10,0��6   $��1��5�      ��5�      �� 5�      $	 1,1&�6*   $	 0,0&�6;   .��5�      �   primaryBackColor1# [ 6'   $ 0Q�6R   � 5�        primaryBackColor2# [ 6'   $ 1Q�6R   5�      ._�5�      �  � RowDefinitions 5�      �� 5�      $��25 �6(   66   �� 5�      $��35 �6(   66   �� 5�      $��* �6(   65   .+�5�      �� -   5         ��Name$ pnlControlBar��5�   !   $��0��5�   !   $ 
Horizontal=�5�   !   $��RightToLeft=�5�   !   
������ $��0,0,5,0q�5�   !   .+�5�      �� -   5         ��Name$ btnClose��5�   !     controlButton#��[ 5�   !   # [ 5�   !   ��5�       �� *Exitcommand+.��5�        $ Xmark=�6+     controlButtonIcon#��[ 68   5�      �� 5�      -   5        $ btnMaximize��5�   !   #��[ 5�   !   # [ 5�   !   .��5�        $ Square=�6+   #��[ 69   5�      �� 5�      -   5        $ btnMinimize��5�   !   #��[ 5�   !    
 color8# [ 5�   !   .��5�        $ WindowMinimize=�6+   $��12��6A   #��[ 6L   5�      5�      � 5�      $��1��6    5�      �� 5�      61   �� 5�      61   .+�5�      �� $��0��6%   $ 
Horizontal=�66   $��Center=�6O   .+�5�        $��20��5�   +   $��20��5�   +      
Foreground# [ 5�   +   $��	35,0,10,0q�5�   +    5�   +   �� *Icon+5�   +   �� 5�      #��[ 5�   (   $��16(�5�   (   $��
Montserrat)�5�   (   $��Medium"�5�   (   $��Center=�5�   (   ��5�   (   �� *	Caption+5�   (   5�      �� 5�      $��1��6%   $ 
Horizontal=�5�   %   $��RightToLeft=�5�   %   $��Center=�5�   %   $��0,0,10,0q�5�   %   .+�5�      ��   
iconButton#��[ 6%   # [
 5�   %   ��5   %   �� *LogoutCommand+.��5  "     $ SignOut=�6/   $��12��5  /   $��12��6;     iconButtonIcon#��[ 5  /   5     �� 5       titleColor3#��[ 5  (   $��
Montserrat)�5  (   $��12(�5  (   $��Center=�5	  (   ��5  (   �� *
Username+5	  (   A� 5
     $��35��6&   $��35��62   #��[ 5  &   $��2��5  &   $��	10,0,10,0q�5  &   ��5  "   �� 5  &    �� ImageSource$ /Images/user.png��61   5     �� 5     #��[ 6%   # [ 5  %   .��5  "     $ Clock=�6/   #��[ 6<   5     �� 5     #��[ 6%   # [ 5  %   .��5  "     $ Envelope=�6/   #��[ 6?   5     �� 5     #��[ 6%   # [ 5  %   .��5  "     $
 Bell=�6/   #��[ 6;   5     5     5     �� 5"     $��2��5#  %   $��25q�5$  %   ��5"  %   �� *CurrentChildView+5$  %   5%     5&     5'     5(     5*     