   M S B A M L   `   `   `  ����C  ?CLRM_MIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:CLRM_MIS.ViewModels.CBFViewModels!CLRM_MIS.ViewModels.CBFViewModels  5      0    *CLRM_MIS.Views.CBFDetailView.CBFDetailInfo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      f bDevExpress.Xpf.Grid.v14.2.Core, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5	      c	 _DevExpress.Xpf.Ribbon.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon 	 5
      d
 `DevExpress.Xpf.Docking.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking 
 5      j fDevExpress.Xpf.LayoutControl.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      ] YDevExpress.Mvvm.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5      A	ViewModel/clr-namespace:CLRM_MIS.ViewModels.CBFViewModels   5        � 	Resources  5       �� 
TargetType �� Property �� Value��%�   '��       '�� H     �� 5   
   " ��6   .�5      ��  � ��$ 15(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5       $��* �6   �� 5!      $��3* �6   .+�5#   
   � $��2��6   .+�5$      �� 
�������$��1q�6(   ._�5%      �� $��承包方详细信息��6   $��5q�6,   
���   �$��3q�6K   $��14(�6_   .��5&      �� .@�5'      �� .��5(      ��  �� Orientation$ 
Horizontal=�6)   .+�5)   "   �� $��承包方编码: ��6,   
����  �6;   �� 5*   "   ��6,   �� *CBFEntity.ID+5+      5,      �� 5-      .��5.      �� $ 
Horizontal=�6)   .+�5/   "   �� $��承包方姓名姓名: ��6,   
����  �6=   �� 50   "   ��6,   �� *CBFEntity.Name+51      52      �� 53      .��54      �� $ 
Horizontal=�6)   .+�55   "   �� $��承包方类型: ��6,   
����  �6;   �� 56   "   ��6,   �� *CBFEntity.Type+57      58      �� 59      .��5:      �� $ 
Horizontal=�6)   .+�5;   "   �� $��证件类型:��6,   
����  �69   �� 5<   "   ��6,   �� *CBFEntity.CertificateType+5=      5>      �� 5?      .��5@      �� $ 
Horizontal=�6)   .+�5A   "   �� $��证件号码: ��6,   
����  �6:   �� 5B   "   ��6,   �� *CBFEntity.CardNumber+5C      5E      �� 5F      .��5G      �� $ 
Horizontal=�6)   .+�5H   "   �� $��承包方地址: ��6,   
����  �6;   �� 5I   "   ��6,   �� *CBFEntity.Address+5J      5L      �� 5M      .��5N      �� $ 
Horizontal=�6)   .+�5O   "   �� $��邮政编码:��6,   
����  �69   �� 5P   "   ��6,   �� *CBFEntity.PostCode+5Q      5T      �� 5U      .��5V      �� $ 
Horizontal=�6)   .+�5W   "   �� $��联系电话: ��6,   
����  �6:   �� 5X   "   ��6,   �� *CBFEntity.Tel+5Y      5\      �� 5]      .��5^      �� $ 
Horizontal=�6)   .+�5_   "   �� $��承包方调查日期:��6,   
����  �6<   �� 5`   "   ��6,   �� *CBFEntity.SurveyDate+5a      5d      �� 5e      .��5f      �� $ 
Horizontal=�6)   .+�5g   "   �� $��承包方调查员: ��6,   
����  �6<   �� 5h   "   ��6,   �� *CBFEntity.Claimsman+5i      5l      �� 5m      .��5n      �� $ 
Horizontal=�6)   .+�5o   "   �� $��承包方调查记事: ��6,   
����  �6=   �� 5p   "   ��6,   �� *CBFEntity.SurveyEvent+5q      5t      �� 5u      .��5v      �� $ 
Horizontal=�6)   .+�5w   "   �� $��公示记事:  ��6,   
����  �6;   �� 5x   "   ��6,   �� *CBFEntity.PublicEvent+5y      5z      �� 5{      .��5|      �� $ 
Horizontal=�6)   .+�5}   "   �� $��公示记事人:  ��6,   
����  �6<   �� 5~   "   ��6,   �� *CBFEntity.PublicEventPerson+5      5�      �� 5�      .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��公示日期:��6,   
����  �69   �� 5�   "   ��6,   �� *CBFEntity.PublicDate+5�      5�      �� 5�      .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��公示审核人: ��6,   
����  �6;   �� 5�   "   ��6,   �� *CBFEntity.PublicCheckPerson+5�      5�      5�      5�      5�      5�      � 5�   
   $��1��6   .+�5�      �� 
�������$��0,1,1,1q�6(   ._�5�      �� $!��承包方家成员庭信息��6   $��5q�6.   
���   �$��3q�6M   $��14(�6a   .��5�      %  DevExpress.Xpf.Grid.GridControl  )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6&   �� *	CBFFamily+   View 5�      #  DevExpress.Xpf.Grid.TableView  5�      &   DevExpress.Xpf.Grid.DataViewBase	   ShowColumnHeaders	 . &   DevExpress.Xpf.Grid.GridViewBase
   ShowGroupPanel
 .  6^      Columns 5�      $  DevExpress.Xpf.Grid.GridColumn  5�      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$
 Name��6-   $  DevExpress.Xpf.Grid.BaseColumn   Header)	  #DevExpress.Xpf.Core.ObjectConverter$ 姓名	 6>     5�      $	 Sex��6-   $ 性别	 6=     5�      $ CertificateType��6-   $ 证件类型	 6I     5�      $ 
CardNumber��6-   $ 证件号码	 6D     5�      $ RelationShip��6-   $ 与户主关系	 6F     5�      $
 Note��6-   $ 成员备注	 6>   5�      5�      5�      5�      � 5�   
   $��1��6   $��1��6   .+�5�      �� 
�������$��0,0,1,1q�6(   ._�5�      �� $!��承包方承包地块信息��6   $��5q�6.   
���   �$��3q�6M   $��14(�6a   .��5�         J� 	AllowDrop .     
ShowBorder .   6&   �� *CBFDK+ 5�        5�      	 . 
 .     AllowEditing .  6s    5�        5�      $
 DKID��6-   $ 地块编码	 6>     5�      $ CBFID��6-   $ 发包方编码	 6?     5�      $ FBFID��6-   $ 发包方编码	 6?     5�      $
 Area��6-   $ 合同面积	 6>     5�      $ GetWay��6-   $! 承包经营权取得方式	 6@     5�      $ 	ContrctID��6-   $ 承包合同编码	 6C     5�      $ TransID��6-   $ 流转合同编码	 6A     5�      $ RightID��6-   $ 承包经营权证编码	 6A   5�      5�      5�      5�      5�      5�      