   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp1.NewFolderWpfApp1.NewFolder  5   	   %    WpfApp1.NewFolder.FrmPorudzbina   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfApp1.NewFolder     5   	     � Title$  Nova Porudzbina��5   	   $	��450��6!   $	��650��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��37* �6   �� 5      $��0* �6   �� 5      $	��43* �6   .+�5   
   �� -   5         ��Name$ label��5      $��IZABERI PICE��6   $
��Left=�66   $��	33,39,0,0q�6Q   $	��Top=�6d    J� RenderTransformOrigin$ 
0.15,0.441&�6|   $��48��6�   $	��150��6�   $��22(�6�   �� 5   
   -   5         ��Name$ cbPice��5      $
��Left=�6#   $��
231,40,0,0q�6>   $	��Top=�6R   $	��230��6j   $��3��6v   $��41��6�   $��22(�6�    �� DisplayMemberPath$ 	NazivPica��6�    �� SelectedValuePath$ PiceID��6�   �� 5   
   -   5        $ label1��5      $��IZABERI KUPCA��6    $
��Left=�68   $��	33,89,0,0q�6S   $	��Top=�6f   $ -0.213,-0.368&�6~   $��48��6�   $	��175��6�   $��22(�6�   �� 5   
   -   5        $ cbKupac��5      $
��Left=�6$   $��
231,91,0,0q�6?   $	��Top=�6S   $	��230��6k   $��3��6w   $��41��6�   $��22(�6�   $ ImeKupca��6�   $ KupacID��6�   �� 5   
   -   5        $ label2��5      $��IZABERI KOLICINU��6    $
��Left=�6;   $��
33,141,0,0q�6V   $	��Top=�6j   $ 0.218,0.125&�6�   $��48��6�   $	��204��6�   $��22(�6�   �� 5   
   -   5        $ 
cbKolicina��5      $
��Left=�6'   $��231,143,0,0q�6B   $	��Top=�6W   $	��230��6o   $��3��6{   $��41��6�   $��22(�6�   $ BrojBoca��6�   $ 
KolicinaID��6�   �� 5   
   -   5        $ label3��5      $��RADNIK��6    $
��Left=�61   $��
33,196,0,0q�6L   $	��Top=�6`   $��48��6x   $	��101��6�   $��22(�6�   �� 5   
   -   5        $ cbRadnik��5      $
��Left=�6%   $��231,198,0,0q�6@   $	��Top=�6U   $	��230��6m   $��3��6y   $��40��6�   $��22(�6�   $ 	RadnikIme��6�   $ RadnikID��6�   �� 5   
   -	   5         ��Name$ 
btnSacuvaj��5      $��SACUVAJ��6%   $��2��67   $
��Left=�6G   $��50��6b   $��
186,82,0,0q�6n   $	��Top=�6�   $	��129��6�   $��22(�6�   6�   �� 5   
   -
   5        $ 	btnOtkazi��5      $��OTKAZI��6$   $��2��65   $
��Left=�6E   $��50��6`   $��186,186,0,0q�6l   $	��Top=�6�   $	��129��6�   $��22(�6�   6�   �� 5   
   -   5        $ label4��5      $��DATUM��6    $
��Left=�60   $��
33,250,0,0q�6K   $	��Top=�6_   $��22(�6w   $ -0.068,0.337&�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $
��Left=�6)   $��231,250,0,0q�6D   $	��Top=�6Y   $��3��6q   $��37��6�   $	��230��6�   $��22(�6�   �� 5   
   -   5        $ label4_Copy��5      $��MAGACIN��6%   $
��Left=�67   $��
33,300,0,0q�6R   $	��Top=�6f   $��22(�6~   $ -0.068,0.337&�6�   �� 5   
   -   5        $ 	cbMagacin��5      $
��Left=�6&   $��231,298,0,0q�6A   $	��Top=�6V   $	��230��6n   $��41��6z   $��3��6�   $ NazivMagacina��6�   $ 	MagacinID��6�   �� 5   
   -   5        $ label4_Copy1��5      $��	TRANSPORT��6&   $
��Left=�6:   $��
33,351,0,0q�6U   $	��Top=�6i   $��22(�6�   $ -0.068,0.337&�6�   $	��150��6�   �� 5   
   -   5        $ cbTransport��5      $
��Left=�6(   $��231,349,0,0q�6C   $	��Top=�6X   $	��230��6p   $��41��6|   $��3��6�   $ OdgovorniZaTransport��6�   $ TransportID��6�   5       5!      