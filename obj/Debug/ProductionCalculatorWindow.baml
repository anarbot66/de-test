   M S B A M L   `   `   `  ����  
EkzamenWPF+    %EkzamenWPF.ProductionCalculatorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$5  /Расчёт продукции из сырья��5   	   $	��400��6+   $	��500��68    � 
ResizeMode$ NoResize=�6D    � WindowStartupLocation$ CenterScreen=�6Z   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��180 �6   �� 5      $��* �6   .+�5   
   �� $ ��Тип продукции:��6   $��0��6*   $��0��67   $��Center=�6G   �� 5   
   -   5         ��Name$ ProductTypeComboBox��5      $��0��60   $��1��6=    �� DisplayMemberPath$
 Name��6M    �� SelectedValuePath$ ProductTypeId��6f   �� 5   
   $ ��Тип материала:��6   $��1��6*   $��0��67   $��Center=�6G   �� 5   
   -   5        $ MaterialTypeComboBox��5      $��1��61   $��1��6>   $
 Name��6N   $ MaterialTypeId��6g   �� 5   
   $-��'Количество сырья (шт):��6   $��2��62   $��0��6?   $��Center=�6O   �� 5   
   -   5         ��Name$ RawQtyTextBox��5      $��2��6)   $��1��66   �� 5   
   $��Параметр 1:��6   $��3��6'   $��0��64   $��Center=�6D   �� 5   
   -   5        $ Param1TextBox��5      $��3��6)   $��1��66   �� 5    
   $��Параметр 2:��6   $��4��6'   $��0��64   $��Center=�6D   �� 5!   
   -   5        $ Param2TextBox��5!      $��4��6)   $��1��66   �� 5#   
   -   5        $��Рассчитать��5#      $��5��6&   $��0��63   $��2��6C   $
��0,10q�6u   �� 5%   
   -   5        	 ��Name$	 ResultTextBlock��5%      $��6��6-   $��0��6:   $��2��6J   $
��Bold"�5&      $��16(�6&   
��� d �
 �� TextAlignment$
 Center=�6K   5'      5(      