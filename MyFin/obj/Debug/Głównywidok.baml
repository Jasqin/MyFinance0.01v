   M S B A M L   `   `   `  ����@  <MyFin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyFinMyFin  5   	       MyFin.Głównywidok   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:MyFin     5   	     � Icon$  ico.ico��5   	    � Title$ Głównywidok��5	   	   $	��600��5
   	   $	��600��6    � WindowStartupLocation$ CenterScreen=�6#    � 
ResizeMode$ NoResize=�6I    � WindowStyle$
 None=�6_   .��5      � $	��700��6    � ForceCursor . $	��600��6+   .+�5   
   � 
���   �$
��Left=�6"   $	��600��6=    . $��Center=�6]   $	��262��6x   .+�5      �� -   5         ��Name$ UserIdTextBox��5      $��20(�6-   $��Center=�6;   $��0,37,0,0q�6X   $	��Top=�6j   $	��200��6�    �� 
IsReadOnly . .��6�   ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � ��
 �� Value

 �   �67   �� 5      	 � ��

 �����67   �� 5      	 � ��$
 0q�6<   �� 5      	 � ��$
 5q�64   �� 5      	 � ��$

 Bold"�67   5      .��5   !   5      �� 5      -   5        $ ExpensesSumTextBox��5      $��Center=�62   $��	0,115,0,0q�6O   $	��Top=�6b   $	��200��6z    . .��6�   ��5      �� 5      " ��6   .�5      �� 	 � ��

 �   �67   �� 5      	 � ��

 �����67   �� 5      	 � ��$
 0q�6<   �� 5      	 � ��$
 5q�64   5       .��5!   !   5"      �� 5#      $��81,250,81,250q�6   $��/icons8-wallet-100.png��6+   $
��Fill=�6K   5'      �� 5(   
   -   5         ��Name$
 Exit��5(      $��X��6   $��Right=�6,   $��	0,10,10,0q�6I   $	��Top=�6\   
���   � � Cursor$
 Hand��6�   $��Microsoft Sans Serif)�6�   
�������$��31��6�   $��26��6�   &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ 	TDataGrid��5)      $
��Left=�6&   $��
280,46,0,0q�6A   $	��Top=�6U      AutoGenerateColumns . $	��488��6�   $	��310��6�   
�������$��2q�6�   �� 5*   
   -   5        $��Dodaj wydatek��5*      $
��Left=�6J   $��
72,426,0,0q�6e   
���   �$��Microsoft Sans Serif)�6�   $��DemiBold"�6�   
�������
�������$	��Top=�6�   $��39��6  $	��120��6  �� 5+   
   -   5        $��Wyloguj się��5+      $
��Left=�6C   $��
72,495,0,0q�6^   
���   �$��Microsoft Sans Serif)�6�   $��DemiBold"�6�   
�������
�������$	��Top=�6�   $��39��6�   $	��118��6	  �� 5,   
   -   5        $
 Mini��5,      $��_��6   $��31��6,   $��26��68   $��1q�6D   $
��Bold"�6Y   $
��Left=�6k   $��
533,10,0,0q�6�   $	��Top=�6�   
���   �$
 Hand��6�   $��Microsoft Sans Serif)�6�   
������� J� RenderTransformOrigin$ -0.861,0.493&�6  50      51      