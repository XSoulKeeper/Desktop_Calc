   M S B A M L   `   `   `  ����   
Kalkulator    Kalkulator.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
Kalkulator��$	��800��$	��550��$	��800��$	��550��.��� .+��� -    ��Name$ BackgroundGif�� K� ZIndex$ -1��$
��1400��$
��1400��$��Bottom=�$��Center=��� -   $��
MenuButton��$��40��$��40��$��0q�
������ $��0q�$
��Left=�$	��Top=�.���� $.��(/Kalkulator;component/Resources/menu.png��$��Uniform=� J� RenderTransformOrigin$ 0.5,0.5&�z��� -   GearRotateTransform�� �� Angle$ 0Q� � 	Resources    RotateRightStoryboard �� 
TargetName �� TargetProperty W� From		 W� To
 g� Duration g� FillBehavior W� EasingFunction.  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  RotateLeftStoryboard��%�   &	        &	 q     �� .��W� $ GearRotateTransform��$ Angle� 0	 360$
 0:0:0.5D�$
 Stop=�   $ EaseOut=��� .��W� $ GearRotateTransform��$ Angle� 0	 -360$
 0:0:0.5D�$
 Stop=�   $ EaseOut=�� -   $��	MenuPopup��$
��Left=� � 	StaysOpen$ False�� � PlacementTarget ��  �� ElementName$ 
MenuButton��.���� 
�������
�������$��1q� �� Padding$ 5q�._��� .+��� -   $��Simple��
 � Tag$ Prosty��$��2q��� -   $��Advanced��$ Naukowy��$��2q��� -   $��CalculatorContent��