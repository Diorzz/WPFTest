   M S B A M L   `   `   `  ����C  ?CLRM_MIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CLRM_MIS.ViewModelsCLRM_MIS.ViewModels  5      K*clr-namespace:CLRM_MIS.Views.CBFDetailViewCLRM_MIS.Views.CBFDetailView  5          CLRM_MIS.Views.CBFView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Core.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      f bDevExpress.Xpf.Grid.v14.2.Core, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5	      c	 _DevExpress.Xpf.Ribbon.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon 	 5
      d
 `DevExpress.Xpf.Docking.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking 
 5      j fDevExpress.Xpf.LayoutControl.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      ] YDevExpress.Mvvm.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5      3	ViewModel!clr-namespace:CLRM_MIS.ViewModels   5      7View*clr-namespace:CLRM_MIS.Views.CBFDetailView   5        � DataContext  5      &   CLRM_MIS.ViewModels.CBFViewModel  5   
    � 	Resources 5         EmployeeCardTemplate � ColumnDefinitions�� 5   
   %  &	        �� 5      .R�5      � $	��295��6   $	��151��6#    5      �� 5      $
��Auto �6+   �� 5      $��* �6+   .+�5      �� $��1��6!   .+�5      �� $��ADDRESS��6$   �� 5      ��6$   �� *CBFModel.ID+�� 5       ��6$   �� *DataContext.Name+�� 5!      $��EMAIL��6$   $��0,13,0,0q�61   �� 5"      ��6$   �� *DataContext.Email+�� 5#      $��PHONE��6$   $��0,13,0,0q�61   �� 5$      ��6$   �� *DataContext.HomePhone+5%      5&      5'      5(      .��5Y      . 
 (DevExpress.Xpf.Docking.DockLayoutManager     
LayoutRoot 5Z   
   ( 
 "DevExpress.Xpf.Docking.LayoutGroup  5[         Items. 5\      ( 
 "DevExpress.Xpf.Docking.LayoutPanel  + 
 %DevExpress.Xpf.Docking.BaseLayoutItem   AllowSizing . "   VerticalScrollBarVisibility$ Disabled=�67   $   HorizontalScrollBarVisibility$ Disabled=�6^      	ItemWidth$	 250 �5]   $   	   
AllowClose	 .  
   	AllowDrag
 .     
AllowFloat .     	AllowHide .     ShowCaption .  ( 
 "DevExpress.Xpf.Docking.ContentItem   Content. 5`      � .+�5a      %  DevExpress.Xpf.Grid.GridControl  -   5        $��MainGrid��5a   *   )  #DevExpress.Xpf.Grid.DataControlBase   
ShowBorder .     AutoExpandAllGroups .    ItemsSource 5b   *   �� *
CBFModel+   SelectedItem 5c   *   �� *	CBFEntity+   View 5h      "	  DevExpress.Xpf.Grid.CardView	  5i   "   &
   DevExpress.Xpf.Grid.DataViewBase 
  ShowColumnHeaders .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .   
  SearchPanelNullText$  搜索承包方 (Ctrl + F)��6`    
  ShowSearchPanelMode$ Always=�6�   % 
  SearchPanelHorizontalAlignment$ Center=�6�    
  AllowEditing .   	  
CardLayout$
 Rows=�6�    	  CardHeaderBinding 5j   /   �� *	Data.Name+ �� RelativeSource ��  �� Mode$
 Self=�   Columns 5l      $  DevExpress.Xpf.Grid.GridColumn  5m   "   $  DevExpress.Xpf.Grid.ColumnBase   IsSmart .     	FieldName$  ID��6@   $  DevExpress.Xpf.Grid.BaseColumn!   Header)  #DevExpress.Xpf.Core.ObjectConverter$! 编码 6O   "   Width$	" 320��6[   #   GroupSummary# 5p      )  #DevExpress.Xpf.Grid.GridSummaryItem  5q   "   )  #DevExpress.Xpf.Grid.SummaryItemBase$   SummaryType$$ Count=�66   5t      5u      5v        5x       . $ Disabled=�66   $ Disabled=�6]   	 .  
 .   .   .   .  $ * �5z   )   %   
ShowBorder% .  . 5|      0   *CLRM_MIS.Views.CBFDetailView.CBFDetailInfo  &   SelectedModel& 6)   �� *DataContext+' �� ElementName$' MainGrid��5}      5~      5�      5�      