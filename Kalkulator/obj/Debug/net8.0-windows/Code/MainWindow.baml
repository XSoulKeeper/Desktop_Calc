   M S B A M L   `   `   `  ����  
Kalkulator    Kalkulator.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Kalkulator��5   	   $	��800��6   $	��550��6)   $	��800��65   $	��550��6E   .��5      � .+�5   
   �� -   5         ��Name$ BackgroundGif��5       K� ZIndex$ -1��5      $
��1400��5      $
��1400��5	      $��Bottom=�5
      $��Center=�5      �� 5   
   -   5        $��
MenuButton��5      $��40��5      $��40��5      $��0q�5      
������ $��0q�5      $
��Left=�5      $	��Top=�5      .��5      �� $.��(/Kalkulator;component/Resources/menu.png��6   $��Uniform=�6F    J� RenderTransformOrigin$ 0.5,0.5&�6X   z�5      �� 5      -   5        GearRotateTransform�� �� Angle$ 0Q�5   C   5       � 	Resources 5         RotateRightStoryboard �� 
TargetName �� TargetProperty W� From		 W� To
 g� Duration g� FillBehavior W� EasingFunction.  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  RotateLeftStoryboard��%�  &	        &	 �     �� 5      .��5      W� $ GearRotateTransform��5      $ Angle�5       05      	 3606"   $
 0:0:0.5D�6+   $
 Stop=�6>    5         5!      $ EaseOut=�6(   5#      5$      �� 5%      .��5&      W� $ GearRotateTransform��5'      $ Angle�5(       05)      	 -3606"   $
 0:0:0.5D�6,   $
 Stop=�6?    5*        5+      $ EaseOut=�6(   5-      5.      5/      50      � 52   
   -   5        $��	MenuPopup��52      $
��Left=�6T    � 	StaysOpen$ False��6e    � PlacementTarget 6!   ��  �� ElementName$ 
MenuButton��.��53      �� 
�������
�������$��1q�6;    �� Padding$ 5q�6O   ._�54      �� .+�55      �� -   5        $��Prosty��55      
 � Tag$ Prosty��6G   $��2q�6T   �� 56      -   5        $��Naukowy��56      $ Naukowy��6H   $��2q�6V   57      58      59      �� 5;   
   -   5        $��CalculatorContent��5;      5<      5=      