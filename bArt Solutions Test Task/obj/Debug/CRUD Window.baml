   M S B A M L   `   `   `  ����S  ObArt Solutions Test Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:bArt_Solutions_Test_TaskbArt_Solutions_Test_Task  5   	   )    #bArt_Solutions_Test_Task.CRUDWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:bArt_Solutions_Test_Task     5   	     � Title$  
CRUDWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��41* �6   �� 5      $	��39* �6   .+�5   
   �� -   5         ��Name$ ContactListBox��5      $��10,10,109,10q�6*   �� 5   
   -   5        $ AcountListBox��5      $��2��6)   $��306,10,357,10q�6=   �� 5   
   -   5        $ IncendentListBox��5      $��1��6,   $��38,10,204,10q�6<   �� 5   
   -   5        $��1��5      $��Delete Contact��6!   $
��Left=�6:   $��
195,10,0,0q�6U   $	��Top=�6i   $	��185��6�   �� 5   
   -   5        $��1��5      $��Delete Account��6!   $
��Left=�6:   $��
195,35,0,0q�6U   $	��Top=�6i   $	��185��6�   6�   �� 5   
   -   5        $��1��5      $��Delete Incindent��6!   $
��Left=�6<   $��
195,60,0,0q�6W   $	��Top=�6k   $	��185��6�   6�   �� 5   
   -   5        $��1��5      $��Update Contact��6!   $
��Left=�6:   $��
195,85,0,0q�6U   $	��Top=�6i   $	��185��6�   6�   �� 5   
   -   5        $��1��5      $��Update Account��6!   $
��Left=�6:   $��195,110,0,0q�6U   $	��Top=�6j   $	��185��6�   6�   �� 5   
   -	   5        $��1��5      $��Update Incindent��6!   $
��Left=�6<   $��195,135,0,0q�6W   $	��Top=�6l   $	��185��6�   6�   �� 5   
   -
   5        $��1��5      $��Add Contact��6!   $
��Left=�67   $��195,160,0,0q�6R   $	��Top=�6g   $	��185��6   6�   �� 5   
   -   5        $��1��5      $��Add Account��6!   $
��Left=�67   $��195,185,0,0q�6R   $	��Top=�6g   $	��185��6   6�   �� 5   
   -   5        $��1��5      $��Add Incindent��6!   $
��Left=�69   $��195,210,0,0q�6T   $	��Top=�6i   $	��185��6�   6�   �� 5   
   -   5        $��1��5      $��Refresh��6!   $
��Left=�63   $��195,391,0,0q�6N   $	��Top=�6c   $	��185��6{   6�   5      5      