   M S B A M L   `   `   `  ����J  FHRManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagementAppHRManagementApp  5      G(clr-namespace:HRManagementApp.ViewModelsHRManagementApp.ViewModels  5      G(clr-namespace:HRManagementApp.ConvertersHRManagementApp.Converters  5      )    #HRManagementApp.Views.ControlWindow   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      0local1clr-namespace:HRManagementApp     5      ;local2(clr-namespace:HRManagementApp.ViewModels     5      ;local3(clr-namespace:HRManagementApp.Converters     5        � WindowStartupLocation$  CenterScreen=�5      $	��700��5      $	��550��5       � Title 5
      �� *Title+ � DataContext 5      7  1HRManagementApp.ViewModels.ControlWindowViewModel  5   
    � 	Resources 5         DataGridTextColumnStyle �� 
TargetType �� Property �� Value  DataGridColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader>   8HRManagementApp.Converters.PositionEnumToStringConverter ! PositionEnumToStringConverter��%+  &	        &	 T     &	 �     �� 5   
   " ��5      .�5      ��  � ��$ Center=�5      5      �� 5   
   "  5      .�5      ��  � ��$ Center=�5      �� 5       � ��$
 Bold"�5      �� 5        � ��$ 12(�5!      5"        5#   
   6/   5$      .��5'      �  � ColumnDefinitions 5(   
   �� 5)      $��* �6   �� 5*      $��* �6    � RowDefinitions 5-   
   �� 5.      $��* �6   �� 5/      $
��Auto �6   .+�52   
   �� $��0��6   $��0��53      $��10q�54      
�������$��1q�56      ._�57      � $��0��6   $��0��58      $��10q�59       5:      �� 5;      $��* �6$   �� 5<      $
��Auto �6$   .+�5?      �� $��Active Employees��6   .��5@      &   System.Windows.Controls.DataGrid  	   AutoGenerateColumns$	 False��5B      
   CanUserAddRows$
 False��5C         CanUserDeleteRows$ False��5D         CanUserResizeColumns$ False��5E         CanUserResizeRows$ False��5F         
IsReadOnly$
 True��5G      $��5q�5H      ��5@      �� *ActiveEmployees+ �� SelectedItem 5A      �� *SelectedEmployee+ �� AlternationCount 5I      �� *ActiveEmployees.Count+   Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn   Header$ Personel��61   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  5M   1      HeaderStyle# [ 5N   1      Binding 5L   1   �� *AlternationIndex+ �� RelativeSource ��  �� AncestorType DataGridRow5N   1     5O      $
 Name��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5Q   1   # [  5R   1   # [ 5S   1    5P   1   �� *Name+5S   1     5T      $ Surname��61   $ * 5V   1   # [  5W   1   # [ 5X   1    5U   1   �� *	Surname+5X   1     5Y      $ Position��61   $ * 5[   1   # [  5\   1   # [ 5]   1    5Z   1   ��  �� Path$ Position� �� 	Converter# [ 5]   1     5^      $ 
Experience��61   $ * 5`   1   # [  5a   1   # [ 5b   1    5_   1   �� *
Experience+5b   1   5d      5e      �� 5g      $��1��6    �� Orientation$ 
Horizontal=�5h      $��Right=�5i      $��Center=�5j      $��5q�5k      .+�5l      �� $
��Save��6   $��5q�5n      ��5m      �� *SaveCommand+5n      �� 5o      $
��Load��6   $��5q�5q      ��5p      �� *LoadCommand+5q      5r      5s      5t      �� 5v   
   $��1��6   $��0��5w      $��10q�5x      
�������$��1q�5z      ._�5{      � $��1��6   $��0��5|      $��10q�5}       5~      �� 5      $��* �6$   �� 5�      $
��Auto �6$   .+�5�      �� $��Positions to Update��6   .��5�        $	 False��5�      $
 False��5�      $ False��5�      $ False��5�      $ False��5�      $
 True��5�      $��5q�5�      ��5�      �� *PositionsToUpdate+ 5�      �� *SelectedPosition+ 5�      �� *PositionsToUpdate.Count+ 5�        5�      $ Personel��61   # [  5�   1   # [ 5�   1    5�   1   �� *AlternationIndex+ ��  DataGridRow5�   1     5�      $
 Name��61   $ * 5�   1   # [  5�   1   # [ 5�   1    5�   1   �� *Name+5�   1     5�      $ Surname��61   $ * 5�   1   # [  5�   1   # [ 5�   1    5�   1   �� *	Surname+5�   1     5�      $ Position��61   $ * 5�   1   # [  5�   1   # [ 5�   1    5�   1   �� $ Position�# [ 5�   1     5�      $ 
Experience��61   $ * 5�   1   # [  5�   1   # [ 5�   1    5�   1   �� *
Experience+5�   1     5�      $ Status��61   $ 65 5�   1   # [  5�   1   # [ 5�   1    5�   1   �� *Status+5�   1   5�      5�      �� 5�      $��1��6   $ 
Horizontal=�5�      $��Right=�5�      $��Center=�5�      $��5q�5�      .+�5�      �� $	��Add��6   $��5q�5�      ��5�      �� *
AddCommand+5�      �� 5�      $
��Edit��6   $��5q�5�      ��5�      �� *EditCommand+5�      �� 5�      $��Remove��6   $��5q�5�      ��5�      �� *RemoveCommand+5�      5�      5�      5�      5�      5�      