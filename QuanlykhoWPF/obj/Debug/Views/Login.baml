   M S B A M L   `   `   `  ����G  CQuanlykhoWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanlykhoWPFQuanlykhoWPF  5   	   G(clr-namespace:QuanlykhoWPF.UserControlVDQuanlykhoWPF.UserControlVD  5   	       QuanlykhoWPF.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanlykhoWPF     5   	   7uc(clr-namespace:QuanlykhoWPF.UserControlVD     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5        $��login��5   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	     LoginVM � DataContext# [ 5   	    � Title$ Login��5   	   $	��450��6   $	��800��6$   .��5      � -   5        ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      � 	 � Color$	 	#FFE63070��6   
 � Offset$
 1Q�61   � 5      $	 	#FFFE8704��6   $
 0Q�61   5      .+�5   
   �� $	��390��6   $	��Top=�6    �� CornerRadius$ 	0 0 180 0��66   ���#100E175       �� 5!   
    �� Orientation$ 
Horizontal=�6   .+�5"      �� $	��350��6   .+�5#      �� $��/Views/ICON4801.png��6   $	��300��65   $	��300��6A   $	��Top=�6N   $��30q�6f   $
��Fill=�6r   5$      �� 5%      $	��350��6   .+�5&      �� $��20 40q�6   .+�5'      �� $��
User Login��6    $��20q�62   
������� �� TextAlignment$ Center=�6Q   $��38(�6h   $��MV Boli)�6v   6�   �� 5(      $ 
Horizontal=�6!   $��10q�6:   .+�5)      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�62   $��25��6>   $��25��6I   
�������6U   �� 5*      $
��10 0q�6<   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter Username��6J   
�������$	��250��6�   
������� �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#FFD94448��6"   �� *
Username+6�   5+      �� 5,      $ 
Horizontal=�6!   $��10q�6:   .+�5-        $
 Lock=�62   $��25��6>   $��25��6I   
�������6U   G� 5.      -   5         G�Name$ PasswordBox��5.   &   $
��10 0q�6;   $ ********��6I   
�������$	��250��6�   
������� G� 
CaretBrush �	#FFD94448 G� SelectionBrush �	#FFD94448.  (System.Windows.Interactivity.Interaction   Triggers 5/      /  )System.Windows.Interactivity.EventTrigger  50   "      	EventName$ PasswordChanged��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 51   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *Passwordcommand+   CommandParameter 52   )   ��  �� ElementName$ PasswordBox��53   #   55      56      �� 57      $��10q�6!   $��Center=�6-   .+�58      �� $	��100��6!   $��40��6-     MaterialDesignRaisedButton#��[ 69   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��59      $��2q�6D   ���#D94448���#D94448
������� � ToolTip$ Login��5:   >   $��Login��6O   ��5;   !   �� *Logincommand+��6B   �� $ login��5<      5=      5>      5?      �� 5@      $	��100��6   .+�5A      �� $��10 20q�6    & "MaterialDesignFloatingActionButton#��[ 6(   $ Close��5B      ��5A   d   Z� ��5B   !   �� *Exitcommand+��6B   �� $ login��.��5C        $ Close=�6.   
�������$��30��6N   $��30��6Y   5E      5F      5G      5H      5I      