;#DropDB GDS.ExpressApp.UserFilterEasyTest

#Application GDS.ExpressApp.UserFilterWin
#Application GDS.ExpressApp.UserFilterWeb
#IfDef GDS.ExpressApp.UserFilterWin

*Action About...
 
*Action OK

#EndIf

#IfDef GDS.ExpressApp.UserFilterWeb
!Action Navigation(My Details)
#EndIf
