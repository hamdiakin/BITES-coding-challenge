   M S B A M L   `   `   `  ����J  FHRManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HRManagementApp.ViewModelsHRManagementApp.ViewModels  5      1clr-namespace:HRManagementAppHRManagementApp  5      1    +HRManagementApp.Views.EditAddEmployeeWindow   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      :local(clr-namespace:HRManagementApp.ViewModels     5      0local1clr-namespace:HRManagementApp     5      $	��300��5
      $	��320��5      $	��300��5      $	��320��5        � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$ 
ToolWindow=�5       � Title 5	      �� *Title+ � DataContext 5      9   3HRManagementApp.ViewModels.EditAddEmployeeViewModel  5   
   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5       $
��Auto �6   �� 5!      $��* �6   .+�5$   
   �� $��Name:��6   $��0��5%      $��0��5&      $
��Left=�5'      $��Center=�5(      $��0,5,5,5q�5)      �� 5+   
   -   5         ��Name$ textBoxEmployeeName��5+      $��0��5-      $��1��5.      $	��0 5q�5/      ��5,      �� *EmployeeName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�	 �� ValidatesOnDataErrors$
	 True��5/      �� 51   
   $��Surname:��6   $��1��52      $��0��53      $
��Left=�54      $��Center=�55      $��0,5,5,5q�56      �� 58   
   -   5        $ textBoxEmployeeSurname��58      $��1��5:      $��1��5;      $	��0 5q�5<      ��59      �� *EmployeeSurname+$ PropertyChanged=�$ TwoWay=�$
	 True��5<      �� 5>   
   $��	Position:��6   $��2��5?      $��0��5@      $
��Left=�5A      $��Center=�5B      $��0,5,5,5q�5C      �� 5E   
   
 �� DisplayMemberPath$
 DisplayText��5G       �� SelectedValuePath$ 	EnumValue��5H      $��2��5I      $��1��5J      $	��0 5q�5K      ��5E      �� *PositionDisplayItems+ �� SelectedValue 5F      �� *SelectedPosition+$ PropertyChanged=�$ TwoWay=�$
	 True��5K      �� 5N   
   $��Experience:��6   $��3��5O      $��0��5P      $
��Left=�5Q      $��Center=�5R      $��0,5,5,5q�5S      �� 5U   
   -   5        $ textBoxEmployeeExperience��5U      $��3��5W      $��1��5X      $	��0 5q�5Y      ��5V      �� *EmployeeExperienceAsString+$ PropertyChanged=�$ TwoWay=�$
	 True��5Y      �� 5[   
   $��Status:��6   $��4��5\      $��0��5]      $
��Left=�5^      $��Center=�5_      $��0,5,5,5q�5`      �� 5b   
   -   5         ��Name$ comboBoxStatus��5b      $��4��5e      $��1��5f      $	��0 5q�5g      ��5c      �� *StatusOptions+ �� SelectedItem 5d      �� *SelectedStatus+$ PropertyChanged=�$ TwoWay=�$
	 True��5g      �� 5i   
   $��Right=�5k      $��5��5l      $��1��5m      $	��100��5n      $
��0 10q�5o      ��5i      �� *
ButtonText+��5j      �� *ButtonCommand+5o      5p      5q      