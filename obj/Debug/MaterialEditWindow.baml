   M S B A M L   `   `   `  ����E  AEkzamenWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:EkzamenWPF
EkzamenWPF  5   	   #    EkzamenWPF.MaterialEditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:EkzamenWPF     5   	     � Title$  MaterialEditWindow��5   	   $	��450��6$   $	��800��61    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterScreen=�6S   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 
HeaderText��5      $��16(�5      $
��Bold"�6"   $��0,0,0,10q�5      �� 5   
   $��1��6   $	��Top=�6"   .+�5      �� $��Тип материала��6   �� 5      -   5         ��Name$ 	TypeCombo��5      �� 5      $��Наименование��6   $��0,10,0,0q�6,   �� 5      -   5         ��Name$ NameText��5      �� 5      $"��Цена за единицу��6   $��0,10,0,0q�6/   �� 5      -   5        $ 	PriceText��5       � ToolTip$7 1Число, >= 0, с точностью до 0.01��6)   �� 5       $'��!Единица измерения��6   $��0,10,0,0q�61   �� 5!      -   5        $ UnitText��5!      �� 5#      $.��(Количество в упаковке��6   $��0,10,0,0q�65   �� 5$      -   5        $ PackQtyText��5$      �� 5&      $,��&Количество на складе��6   $��0,10,0,0q�64   �� 5'      -   5        $ StockQtyText��5'      �� 5)      $1��+Минимальное количество��6   $��0,10,0,0q�66   �� 5*      -   5        $ 
MinQtyText��5*      5+      �� 5.   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5/      �� -	   5        $��Сохранить��5/      $	��100��51      $��0,0,10,0q�6!   �� 52      -
   5        $��Отмена��52      $	��100��54      55      56      57      