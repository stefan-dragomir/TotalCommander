   M S B A M L   `   `   `  ����I  ETotalCommander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TotalCommanderTotalCommander  5   	        TotalCommander.TextCompare   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TotalCommander     5   	   -   5          � Title$  Compare Text��5   	   $	��700��6   $
��1000��6+   .��5	      � -   5         �Name$ gridFileCompare��5	       � RowDefinitions 5
      �� 5      $
��20px �6   �� 5      $��* �6   �� 5      $
��30px �6    � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5      � -   5        $ gridInputsLeft��5   	   $��0��6!   $��0��6.   $��0,0,0,0q�6>   $��Stretch=�6O   $��Stretch=�6k   .+�5      �� -   5         ��Name$ btnLoadLeft��5      $��>>��6!   $
��Left=�6.   $��Stretch=�6I   $��20��6e   $��0,0,0,0q�6p   6�   �� 5      -   5         ��Name$ txtPathLeft��5      $��25,0,0,0q�6"   $��Stretch=�64   $��Stretch=�6P   $��Center=�6n   5      � 5      -   5        $ gridInputsRight��5   	   $��0��6"   $��2��6/   $��0,0,0,0q�6?   $��Stretch=�6P   $��Stretch=�6l   .+�5      �� -   5        $ btnLoadRight��5      $��>>��6"   $
��Left=�6/   $��Stretch=�6J   $��20��6f   $��0,0,0,0q�6q   6�   �� 5      -   5        $ txtPathRight��5      $��25,0,0,0q�6#   $��Stretch=�65   $��Stretch=�6Q   $��Center=�6o   5      �� 5      -	   5         ��Name$ gridSplitter��5      $��1��6'   $��1��64   $��2,0,2,0q�6D   $��2��6U   $��Stretch=�6_   $��Center=�6{   �� 5      -
   5         ��Name$ txtCompareLeft��5      $��1��6(   $��0��65   $��0,0,0,0q�6E    �� 
IsReadOnly . "	 �� VerticalScrollBarVisibility$
	 Auto=�6h   $
 �� HorizontalScrollBarVisibility$

 Auto=�6�   6�   �� 5      -   5        $ txtCompareRight��5      $��1��6)   $��2��66   $��0,0,0,0q�6F    . $
	 Auto=�6i   $

 Auto=�6�   6�   �� 5      $��2��6   $��3��6   $��0,0,0,0q�60   .+�5       �� -   5        $ 
btnCompare��5       $��Compare!��6    $	��0,5q�63   $��80��6@   6K   5!      5"      5#      