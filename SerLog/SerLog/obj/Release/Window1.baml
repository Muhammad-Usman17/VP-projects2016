   M S B A M L   `   `   `  ���� A  =SerLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SerLogSerLog      SerLog.Window1   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:SerLog       � Title$  SerLog��$	��500��$	��700�� � WindowStartupLocation$ CenterScreen=����	#FFFDFDFD���	#FF0E3353.��(�  (� Stretch$ Uniform=� (� StretchDirection$
 Both=�.��� $	��373��$	��Top=�$	��553������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF575F72�� � Offset$ 0.978Q�� $ 	#FF93E4E4��$ 0.191Q� � RowDefinitions �� $
��131* ��� $
��188* �.+��� -   	 ��Name$	 button��$��Start��$
��Left=�$��	22,41,0,0q�$	��Top=�$��89��$��26������ $ 0.5,1&�
 � MappingMode$
 RelativeToBoundingBox=�$ 0.5,0&�.��� $ White��$ 0.236Q�� $ 	#FF41C55F��$ 0.003Q��� -    ��Name$ 	listView1��$
��Left=�$	��147��$��
301,30,0,0q�$	��Top=�$	��203��$��1�����	#FFD2FBCF �� View �� .P��� $��Service Name���� -    ��Name$ label��$��All Services��$
��Left=�$��16,3,0,0q�$	��Top=�$��72��$��26��$��1���� -   $ label1��$��Monitored service��$
��Left=�$��	297,3,0,0q�$	��Top=�$	��106��$��26��$��1��o� -    o�Name$
 menu��$
��Left=�$��19��$	��Top=�$	��478�����	#FFB1C4DA$��1,0,0,0q�.@�m� $
��Home��$��43��.@�m� -   $��Start��m� -   $
��Stop��m� $	��New��m� $��............��m� -   $
��Exit��m� -	   $
��View��.@�m� -
   $��view Log��m� -   $��	Log print��m� -   $��
Delete log��m� $��Setting��.@�m� -   $��Configuration Setting��m� -   $��Email Setting���� $
��Left=�$	��100��$��	-1,99,0,0q�$	��Top=�$	��554�� J� RenderTransformOrigin$ 0.502,0.423&�$��2�����	#FF804545z�V� .~��� ��  �� AngleX$ 0.562Q��� T�  T� X$ 0.414Q��� -   $	 button1��$��Email Setting��$
��Left=�$��
358,32,0,0q�$	��Top=�$	��101��$��38�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  �� -   $	 button2��$
��Stop��$
��Left=�$��
138,41,0,0q�$	��Top=�$��90��$��26������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFF7F5F5��$ 0.267Q�� $ 	#FFEE7575���� -   $	 button4��$��Log View��$
��Left=�$��
357,82,0,0q�$	��Top=�$	��104��$��39��   �� $
��Left=�$	��100��$��
215,34,0,0q�$	��Top=�$	��130��$ 0.5,0.5&����� $ 0.5,1&�$ 0.5,0&�.��� $ Black��$ 0.191Q�� $ 	#FFB89696��$ 0.983Q�z�V� .~��� �� ��  �� Angle$ 90.305Q�T� �� -   $	 button5��$��Sign Out��$
��Left=�$��479,0,-2,130q�$��76�����	#FFF7D8D9 J� OpacityMask ��  �� Color# � ���� -   $	 button6��$��Remove��$
��Left=�$��
139,80,0,0q�$	��Top=�$��87��$��26���� -    ��Name$ listBox��$
��Left=�$	��148��$��	16,33,0,0q�$��1��$	��Top=�$	��176�����	#FFF0D7D7�� -   $	 button7��$
��Show��$
��Left=�$��97,5,0,0q�$��1��$	��Top=�$��75�� � ToolTip$ List down all Services���� -   $	 button3��$	��Add��$
��Left=�$��
212,75,0,0q�$��1��$	��Top=�$��75���� -   $	 button8��$��Remove��$
��Left=�$��212,113,0,0q�$��1��$	��Top=�$��75��