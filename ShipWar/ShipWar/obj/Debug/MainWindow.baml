   M S B A M L   `   `   `  ����B  >ShipWar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ShipWarShipWar  5   	       ShipWar.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ShipWar     5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � Title$ 
MainWindow��5   	   $	��600��6   $
��1000��6)    � Cursor 5   	   �� *Cursor+   SW_STD_CURSOR �� Source# [  .��5      �  � ColumnDefinitions 5   
   �� 5      $��2 �6   �� 5      $	��996 �6   �� 5      $��2 �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��568 �6   �� 5      $��2 �6   .+�5   
   �� $7��1Pictures\backgrounds\background2_1000x600_Cut.jpg��6   $
��Left=�6K   $	��604��6f   $	��Top=�6s   $
��1000��6�   $��3��6�   $��3��6�   $��0,0,0,-4q�6�   �� 5   
   -   5         ��Name$ Cnvs_Titelbar��5      $y�Visible=�6(   .+�5      ��   Window_Border_Sides#��[ 6   $��3��6E    �� Left$	 998��6V   $	��600��6h   $��2��6t   z�5      V� 5      .~�5      �� 	 �� ScaleX$	 -1Q�6)   �� 5      �� 5      
 �� Angle$	
 -90Q�6*   T� 5       5!      ��5#      �� 5$       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;    �� RelativeTransform 5%      V� 5&      .~�5'   "   ��  �� ScaleY$ 1Q�61   $	 -1Q�6<   �� 5(   "    �� AngleY$ 0Q�60    �� AngleX$ 0Q�6;   �� 5)   "   $
 0Q�62   T� 5*   "   5+      .��5-      �  � Color$ Black��6'   � 5.      $ 	#FFA2A2A2��6'    � Offset$ 1Q�69   5/      51      �� 52        Window_Border_Bottom#��[ 6   $��2��6F   $��3��6S   
 �� Top$	 598��6g   $	��998��6x   �� 53      #��[ 6   $��2��6E   $��3��6U   $	��600��6f   $
 -299��6r   $	 299��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��2��6�   z�54      V� 55      .~�56      �� �� 57      �� 58      $	
 -90Q�6*   T� 59      5:      ��5<      �� 5=      $ 0.5,1&�6*   $ 0.5,0&�6;    5>      V� 5?      .~�5@   "   �� $ 1Q�61   $	 -1Q�6<   �� 5A   "   $ 0Q�60   $ 0Q�6;   �� 5B   "   $
 0Q�62   T� 5C   "   5D      .��5F      � $ Black��6'   $ 1Q�65   � 5G      $ 	#FFA2A2A2��6'   $ 0Q�69   5H      5J      �� 5K      $��3��6   $��0��6,     TitelBar_Top#��[ 69   � 5L      $
��Left=�6   $��30��6.   $	��Top=�6:   $	��996��6R   $��1��6^    5M      �� 5N      $��35 �6'   �� 5P      $��35 �6'   �� 5R      $	��860 �6'   �� 5T      $��35 �6'   �� 5V      $��37 �6'   .+�5Z      �� $y�Hidden=�6   $,��&Pictures\Logo\sw_Logo_Little_Steel.png��6,   $
��Left=�6\   $��26��6w   $	��Top=�6�   $��27��6�   $��2,2,0,0q�6�   �� 5[      -   5         ��Name$ LBL_TitelBar_Main��5[      $�� ��63     TitelBar_MainLabel#��[ 6>   $��2��6j   �� 5\      -   5         ��Name$ BTN_Window_Minimize��5\      $��V��66    ! Window_Action_Minimize_Button#��[ 6B   $��3��6y   $
��Left=�6�   $	��Top=�6�   $��3,0,0,0q�6�   6�   �� 5]      -   5        $ BTN_Window_Close��5]      $��X��63     Window_Action_Close_Button#��[ 6?   $��4��6s   $
��Left=�6�   $	��Top=�6�   $��1,0,0,0q�6�   6�   5^      5_      �� 5`   
   -   5         ��Name$ MainContent��5`      $��1��6.   $
��Left=�6>   $��1��6Y   $	��Top=�6f   $	��568��6~   $	��996��6�   �� 5a   
   -   5        $ CNVS_MESSAGE_BAR��5a      $y�Hidden=�6+   .+�5b      �� $	��568��6   $
��1000��6%   $ 30��62   ��5c      �� 5d      $ 0.5,1&�6*   $ 0.5,0&�6;    �� Opacity$	 0.5Q�6N   .��5e      � $ Black��6'   $
 0.47Q�65   � 5f      $ 	#FF252525��6'   $ 1Q�69   � 5g      $ 	#FF1F1F1F��6'   5h      5j      �� 5k      $��1��6   $
��Left=�6(   $	��307��6C   $��	0,124,0,0q�6P   $��1��6c   $	��Top=�6p   $	��996��6�   ��5l      �� 5m       �� ImageSource$4 .Pictures/Backgrounds/GameBoard_Info_Little.png��6   5o      �� 5p      -   5        $ LBL_oMessageBarHeader��5p      $��Messagebar Header��63     MessagebarHeaderLabel#��[ 6O   $��1��6~   $
��Left=�6�   $��258,153,0,0q�6�   $��1��6�   $	��Top=�6�   �� 5q      -	   5         ��Name$ LBL_oMessageBarText��5q      $
��Wrap=�65   $��Messagebar Text��6I     MessagebarTextBlock#��[ 6`   $��1��6�   $
��Left=�6�   $��258,204,0,0q�6�   $��1��6�   $	��Top=�6�   $	��637��6�   $	��150��6�   �� 5r      -
   5        $��OK��5r       	 UA_Default_Button#��[	 6"   $��1��6M   $��Center=�6]   $��1��6z   $	��Top=�6�   $��91��6�   $��460,370,445,0q�6�   $��34��6�   6�   5s      5t      5u      