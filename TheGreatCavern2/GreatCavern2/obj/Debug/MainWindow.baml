   M S B A M L   `   `   `  ����G  CGreatCavern2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GreatCavern2GreatCavern2  5   	       GreatCavern2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GreatCavern2     5   	   -   5          �Name$  The_Great_Cavern_2��5   	    � Title$ The Great Cavern 2��5
   	   #��Z��5   	   #��Z��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��414* �6   �� 5      $	��35* �6   �� 5      $
��227* �6   �� 5      $	��39* �6   .+�5   
   �� -   5         ��Name$ textBox��5      $
��Left=�6=   $��0,3,0,0q�6X    �� TextWrapping$
 Wrap=�6i   $�� ��6}   $
��1275��6�   $��26(�6�   $��Cambria)�6�   $��3��6�   �� 5   
   -   5         ��Name$ 	textBlock��5      	 �� TextAlignment$	 Center=�6'   $��233,0,233,226q�6>   $
��Wrap=�6U   $�� ��6i   $��1��6q   $��2��6~   $��18(�6�   $��Cambria)�6�   $
��Bold"�6�   �� 5   
   $��1q�6   $��0,73,994,71q�6%   ._�5      �� -   5        
 ��Name$
 Frame��5      $
��Left=�6$   $	��270��6?   $	��Top=�6L   $	��281��6d   $��-1q�6p   .+�5      �� -   5         ��Name$	 Map��5      $   GreatCavern2.DraggableExtender   CanDrag . $	��663��6M   $	��642��6Z    �� Left$
 -184��6f   
 �� Top$
 -197��6y   5      5       �� 5!   
   $��1q�6   ���	#FF000000$��281,0,281,0q�5"   )   $	��404��6>   $	��Top=�6K   ._�5#      �� -   5        $ image��5#      $
��Fill=�6#   5$      ,� 5%   
   -   5         ,�Name$ Scroller��5%   #   $��0,1,0,2q�65   $��2��6F   .��5&      /� -   5         /�Name$	 Doc��5&      .T�5'      J� -	   5         J�Name$
 Test��5'      $��15(�6+   $��Cambria)�69   5(      5)      �� 5+   
   $��2q�6   $��1047,0,0,53q�6%   ._�5,      �� $��-2q�6   .+�5-      �� -
   5         ��Name$ listView��5-      $��1039,0,0,71q�6/   $	��306��6D   $��Bottom=�6Q   5.      �� 5/      -   5        $ 
textBlock1��5/      $
��Left=�60   $��1039,10,0,0q�6K   $
��Wrap=�6`   $��	Inventory��6t   $	 Center=�6�   $
��Bold"�6�   $��Cambria)�6�   $	��236��6�   $��37��6�   $	��Top=�6�   50      51      53      54      