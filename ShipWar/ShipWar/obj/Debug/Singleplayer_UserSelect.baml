   M S B A M L   `   `   `  ����B  >ShipWar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ShipWarShipWar  5      %    ShipWar.Singleplayer_UserSelect   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:ShipWar     5      -   5        .��5
      � .+�5   
   �� -   5          ��Name$  BTN_NewPlayer��5      $��
New Player��6(      UA_Default_Button#��[  6=   $��Center=�6�   $	��Top=�6�   $	��192��6�   $��48��6�   $��402,27,402,0q�6�   ��5      �� 5       �� ImageSource$( "Pictures/Button/BTN_Background.png��6   5      �� 5   
   -   5         ��Name$ CNVS_Screen_PlayerInfo��5      $��Center=�61   $	��190��6N   $	��Top=�6[   $	��424��6s   $��286,232,286,0q�6   .+�5      �� -   5         ��Name$ IMG_Screen_PlayerInfo��5      $)��#Pictures\Backgrounds\Flatscreen.png��63   $	��190��6`   $	��438��6m    �� Left$ -7��6y   �� 5      -   5         ��Name$ LBL_sPlayerNumber��5        ShipWarConsoleLabel#��[ 6/   $��Right=�6\   $��Player��6   $ 16��6�   
 �� Top$ 36��6�   $��85��6�   �� 5      -   5        $ LBL_oPlayerNumber��5      #��[ 6/   $
��Left=�6\   $	��123��6~   $	 104��6�   $ 36��6�   $��79��6�   �� 5      -   5        $ LBL_sPlayerName��5      #��[ 6-   $��Right=�6Z   $��Name:��6}   $ 10��6�   $ 79��6�   $	��119��6�   �� 5      -   5        $ LBL_oPlayerName��5      #��[ 6-   $
��Left=�6Z   $��
David Wolf��6|   $	 134��6�   $ 79��6�   $	��264��6�   �� 5      -	   5        $ LBL_sPlayerPoints��5      #��[ 6/   $��Right=�6\   $��Punkte:��6   $ 10��6�   $	 121��6�   $	��119��6�   �� 5      -
   5        $ LBL_oPlayerPoints��5      #��[ 6/   $
��Left=�6\   $
��8000��6~   $	 134��6�   $	 121��6�   $��83��6�   5      �� 5   
   -   5        $ CNVS_Screen_ChoosePlayer��5      $��Center=�63   $	��190��6P   $	��Top=�6]   $	��424��6u   $��286,232,286,0q�6�   .+�5      �� -   5        $ IMG_Screen_ChoosePlayer��5      $)��#Pictures\Backgrounds\Flatscreen.png��65   $	��190��6b   $	��438��6o   $ -7��6{   �� 5      -   5        $ LBL_sChoosePlayerInfo��5      #��[ 63   $��Center=�6`   $��Choose Your Player...��6�   $ 16��6�   $ 76��6�   $	��394��6�   5      �� 5   
   -   5        $ CNVS_CMBX_SelectPlayer��5      $��Center=�61   $��379,124,376,406q�6N   $	��241��6g   .+�5      �� -   5         ��Name$ CMBX_LB_SelectPlayer��5      $y�Hidden=�64   $
��Left=�6H   $	��115��6c   $��Visible=�6p   $	��Top=�6�   $	��241��6�   $	��1,0q�6�   $ 36��6�   ��6�   Z� ��5      �� 5       $/ )Pictures/Backgrounds/background1_hell.jpg��6!    �� Opacity$	 0.8Q�6Y   5"      �� 5#      -   5        $  CMBX_SelectPlayer��5#        SW_ComboBox_Main_Button#��[ 60   $
��Left=�6a   $��Center=�6�   $	��Top=�6�   $	��241��6�   $��38��6�   ��5$      �� 5%      $$ Pictures/Form/CMBX_Default.png��6!   .��5'      �� -   5        $ CMBX_LBL_SelectPlayer��5'      $��Select Player��67   $	��200��6O     SW_ComboBox_Label#��[ 6[   ��5(      �� 5)      	 �� EndPoint$	 0.5,1&�6.   
 �� 
StartPoint$
 0.5,0&�6?   .��5*      �  � Color$ Black��6+    � Offset$ 0Q�69   � 5+      $ 	#FF6C461F��6+   $ 1Q�6=   5,      5.      5/      50      �� 51   
   -   5        $  BTN_StartGame��51      $��
Start Game��6(   #��[  6=   $��Center=�6�   $	��Top=�6�   $	��192��6�   $��48��6�   $��402,454,402,0q�6�   ��52      �� 53      $( "Pictures/Button/BTN_Background.png��6   55      �� 56   
   $
��Left=�6   $	��568��6/   
���   �$	��Top=�6K   $	��281��6c   ��57      �� 58      $/ )Pictures/Backgrounds/background1_hell.jpg��6   5:      �� 5;   
   $
��Left=�6   $	��568��6/   
���   �$	��Top=�6K   $	��281��6c   $��	715,0,0,0q�6o   ��5<      �� 5=      $/ )Pictures/Backgrounds/background1_hell.jpg��6   5?      �� 5@   
   -   5        $ 
IMG_INST_2��5@      $'��!Pictures/Backgrounds/INST_2_2.png��6$   $
��Left=�6O   $	��176��6j   $��	10,30,0,0q�6w   $	��Top=�6�   $	��261��6�   �� 5A   
   -   5        $ IMG_INST_WARN_1��5A      $3��-Pictures/Backgrounds/INST_Warning_Table_1.png��6)   $
��Left=�6`   $	��140��6{   $��
724,27,0,0q�6�   $	��Top=�6�   $	��262��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5B   
   -   5        $ IMG_INST_WARN_2��5B      $3��-Pictures/Backgrounds/INST_Warning_Table_1.png��6)   $
��Left=�6`   $	��140��6{   $��	9,225,0,0q�6�   $	��Top=�6�   $	��262��6�   $ 0.5,0.5&�6�   �� 5C   
   -   5        $ 
IMG_INST_3��5C      $'��!Pictures/Backgrounds/INST_3_1.png��6$   $
��Left=�6O   $	��160��6j   $��724,386,0,0q�6w   $	��Top=�6�   $	��262��6�   $ 0.5,0.5&�6�   �� 5D   
   -   5        $ 
IMG_INST_4��5D      $'��!Pictures/Backgrounds/INST_4_1.png��6$   $
��Left=�6O   $	��172��6j   $��
16,386,0,0q�6w   $	��Top=�6�   $	��250��6�   $ 0.5,0.5&�6�   �� 5E   
   -   5        $ IMG_INST_WARN_3��5E      $3��-Pictures/Backgrounds/INST_Warning_Table_1.png��6)   $
��Left=�6`   $	��140��6{   $��724,209,0,0q�6�   $	��Top=�6�   $	��262��6�   $ 0.5,0.5&�6�   5H      5I      