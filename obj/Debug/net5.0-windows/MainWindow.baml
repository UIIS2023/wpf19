   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  P I V N I C A��5
   	   $
��auto��6   $
��auto��6-   
����İ� � SizeToContent$ Manual=�6V   .��5      � $��0,9,0,0q�6    � ColumnDefinitions 5   
   �� 5      $	��29* �6   �� 5      $	��29* �6   �� 5      $	��29* �6   �� 5      $	��29* �6   �� 5      $��1088* �6   .+�5   
   � $��4��6   $��2��6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Coral��6#    � Offset$ 1Q�61   � 5      $ White��6#   $ 0.979Q�61   � 5      $ 	#FF2E2C2C��6#   � 5      $ White��6#   $ 0.027Q�61   5      5      � 5    
   $��5��6   $��2��6   .+�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCentralni��5!      $��5��62   ���	#FF6C8A93   AlternatingRowBackground
 �����6Y   5"      � 5$   
   $��10,0,5,0q�6   $��4��6!   .+�5%      (� .��5&      � $	��462��6   $	��100��6$   	 � RowDefinitions	 5(      �� 5)      $	��45* �6(   �� 5*      $	��45* �6(   �� 5+      $	��45* �6(   �� 5,      $	��45* �6(   �� 5-      $	��45* �6(   �� 5.      $	��45* �6(   �� 5/      $	��45* �6(   �� 50      $	��45* �6(   �� 51      $	��45* �6(   �� 52      $	��45* �6(   �� 53      $	��45* �6(   �� 54      $	��45* �6(   .+�56      �� -   5        
 ��Name$
 	btnRadnik��56      $��RADNIK��60   $��10q�6B   $��1��6O   6\   �� 57      -   5        $
 btnKupac��57      $��KUPAC��6/   $��10q�6?   $��2��6L   6Z   �� 58      -   5        $
 btnPice��58      $��PIĆE��6.   $��10q�6>   $��3��6K   6X   �� 59      -   5        $
 btnKolicina��59      $��	KOLIČINA��62   $��4��6F   $��10q�6T   6a   �� 5:      -   5        $
 
btnMagacin��5:      $��MAGACIN��61   $��5��6D   $��10q�6R   6_   �� 5;      -   5        $
 btnPorudzbina��5;      $��PORUDZBENICA��64   $��6��6L   6Y   �� 5=      -   5        $
 btnDodaj��5=      $��DODAJ��6/   $��9��6?   6M   �� 5>      -	   5        $
 	btnIzmeni��5>      $��IZMENI��60   $��10��6A   6P   �� 5?      -
   5        $
 	btnObrisi��5?      $��OBRISI��60   $��11��6A   6O   5A      5B      5C      (� 5D   
   $��4��6   $��2��6"   .��5E      �� -   5         ��Name$ MainDisplay��5E      $	��800��62   $
��1126��6?   5G      5H      5I      