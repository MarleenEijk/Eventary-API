œ
yD:\Fontys\2025-2026\Semester 3.1\Individueel project\Eventary\Eventary-API\Eventary-API\Controllers\CategoryController.cs
	namespace 	
Eventary_API
 
. 
Controllers "
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public		 

class		 
CategoryController		 #
:		$ %

Controller		& 0
{

 
private 
readonly 
CategoryService (
_categoryService) 9
;9 :
public 
CategoryController !
(! "
CategoryService" 1
categoryService2 A
)A B
{ 	
_categoryService 
= 
categoryService .
;. /
} 	
[ 	
HttpGet	 
] 
[ 	 
ProducesResponseType	 
< 
List "
<" #
CategoryDto# .
>. /
>/ 0
(0 1
StatusCodes1 <
.< =
Status200OK= H
)H I
]I J
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status400BadRequest* =
)= >
]> ?
public 
async 
Task 
< 
IEnumerable %
<% &
CategoryDto& 1
>1 2
>2 3!
GetAllCategoriesAsync4 I
(I J
)J K
{ 	
return 
await 
_categoryService )
.) *!
GetAllCategoriesAsync* ?
(? @
)@ A
;A B
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
< 
CategoryDto )
>) *
(* +
StatusCodes+ 6
.6 7
Status200OK7 B
)B C
]C D
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status404NotFound* ;
); <
]< =
public 
async 
Task 
< 
IActionResult '
?' (
>( ) 
GetCategoryByIdAsync* >
(> ?
long? C
idD F
)F G
{ 	
var 
category 
= 
await  
_categoryService! 1
.1 2 
GetCategoryByIdAsync2 F
(F G
idG I
)I J
;J K
if   
(   
category   
==   
null    
)    !
{!! 
return"" 
NotFound"" 
(""  
$str""  5
)""5 6
;""6 7
}## 
return$$ 
Ok$$ 
($$ 
category$$ 
)$$ 
;$$  
}%% 	
}&& 
}'' ¾@
xD:\Fontys\2025-2026\Semester 3.1\Individueel project\Eventary\Eventary-API\Eventary-API\Controllers\CompanyController.cs
	namespace 	
Eventary_API
 
. 
Controllers "
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public		 

class		 
CompanyController		 "
:		# $

Controller		% /
{

 
private 
readonly 
CompanyService '
_companyService( 7
;7 8
public 
CompanyController  
(  !
CompanyService! /
companyService0 >
)> ?
{ 	
_companyService 
= 
companyService ,
;, -
} 	
[ 	
HttpGet	 
] 
[ 	 
ProducesResponseType	 
< 
List "
<" #

CompanyDto# -
>- .
>. /
(/ 0
StatusCodes0 ;
.; <
Status200OK< G
)G H
]H I
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status400BadRequest* =
)= >
]> ?
public 
async 
Task 
< 
IEnumerable %
<% &

CompanyDto& 0
>0 1
>1 2 
GetAllCompaniesAsync3 G
(G H
)H I
{ 	
return 
await 
_companyService (
.( ) 
GetAllCompaniesAsync) =
(= >
)> ?
;? @
} 	
[ 	
HttpGet	 
( 
$str 
, 
Name 
= 
$str  0
)0 1
]1 2
[ 	 
ProducesResponseType	 
< 

CompanyDto (
>( )
() *
StatusCodes* 5
.5 6
Status200OK6 A
)A B
]B C
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status404NotFound* ;
); <
]< =
public 
async 
Task 
< 
IActionResult '
>' (
GetCompanyByIdAsync) <
(< =
int= @
idA C
)C D
{ 	
var 
company 
= 
await 
_companyService  /
./ 0
GetCompanyByIdAsync0 C
(C D
idD F
)F G
;G H
if   
(   
company   
==   
null   
)    
{!! 
return"" 
NotFound"" 
(""  
)""  !
;""! "
}## 
return%% 
Ok%% 
(%% 
company%% 
)%% 
;%% 
}&& 	
[(( 	
HttpPost((	 
](( 
[)) 	 
ProducesResponseType))	 
<)) 

CompanyDto)) (
>))( )
())) *
StatusCodes))* 5
.))5 6
Status201Created))6 F
)))F G
]))G H
[** 	 
ProducesResponseType**	 
(** 
StatusCodes** )
.**) *
Status400BadRequest*** =
)**= >
]**> ?
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
AddCompanyAsync++) 8
(++8 9
[++9 :
FromBody++: B
]++B C

CompanyDto++D N

companyDto++O Y
)++Y Z
{,, 	
if-- 
(-- 

companyDto-- 
==-- 
null-- "
||--# %
string--& ,
.--, -
IsNullOrWhiteSpace--- ?
(--? @

companyDto--@ J
.--J K
Name--K O
)--O P
)--P Q
{.. 
return// 

BadRequest// !
(//! "
$str//" 9
)//9 :
;//: ;
}00 
try22 
{33 
var44 
createdCompany44 "
=44# $
await44% *
_companyService44+ :
.44: ;
AddCompanyAsync44; J
(44J K

companyDto44K U
)44U V
;44V W
return55 
CreatedAtRoute55 %
(55% &
$str55& 6
,556 7
new558 ;
{55< =
id55> @
=55A B
createdCompany55C Q
.55Q R
Id55R T
}55U V
,55V W
createdCompany55X f
)55f g
;55g h
}66 
catch77 
(77 
ArgumentException77 $
ex77% '
)77' (
{88 
return99 

BadRequest99 !
(99! "
ex99" $
.99$ %
Message99% ,
)99, -
;99- .
}:: 
};; 	
[== 	

HttpDelete==	 
(== 
$str== 
)== 
]== 
[>> 	 
ProducesResponseType>>	 
(>> 
StatusCodes>> )
.>>) *
Status204NoContent>>* <
)>>< =
]>>= >
[?? 	 
ProducesResponseType??	 
(?? 
StatusCodes?? )
.??) *
Status404NotFound??* ;
)??; <
]??< =
public@@ 
async@@ 
Task@@ 
<@@ 
IActionResult@@ '
>@@' (
DeleteCompanyAsync@@) ;
(@@; <
int@@< ?
id@@@ B
)@@B C
{AA 	
varBB 
companyBB 
=BB 
awaitBB 
_companyServiceBB  /
.BB/ 0
GetCompanyByIdAsyncBB0 C
(BBC D
idBBD F
)BBF G
;BBG H
ifCC 
(CC 
companyCC 
==CC 
nullCC 
)CC  
{DD 
returnEE 
NotFoundEE 
(EE  
)EE  !
;EE! "
}FF 
returnGG 
	NoContentGG 
(GG 
)GG 
;GG 
}HH 	
[JJ 	
HttpPutJJ	 
(JJ 
$strJJ 
)JJ 
]JJ 
[KK 	 
ProducesResponseTypeKK	 
<KK 

CompanyDtoKK (
>KK( )
(KK) *
StatusCodesKK* 5
.KK5 6
Status200OKKK6 A
)KKA B
]KKB C
[LL 	 
ProducesResponseTypeLL	 
(LL 
StatusCodesLL )
.LL) *
Status400BadRequestLL* =
)LL= >
]LL> ?
[MM 	 
ProducesResponseTypeMM	 
(MM 
StatusCodesMM )
.MM) *
Status404NotFoundMM* ;
)MM; <
]MM< =
publicNN 
asyncNN 
TaskNN 
<NN 
IActionResultNN '
>NN' (
UpdateCompanyAsyncNN) ;
(NN; <
intNN< ?
idNN@ B
,NNB C
[NND E
FromBodyNNE M
]NNM N

CompanyDtoNNO Y

companyDtoNNZ d
)NNd e
{OO 	
ifPP 
(PP 

companyDtoPP 
==PP 
nullPP "
||PP# %
stringPP& ,
.PP, -
IsNullOrWhiteSpacePP- ?
(PP? @

companyDtoPP@ J
.PPJ K
NamePPK O
)PPO P
)PPP Q
{QQ 
returnRR 

BadRequestRR !
(RR! "
$strRR" 9
)RR9 :
;RR: ;
}SS 
varUU 
existingCompanyUU 
=UU  !
awaitUU" '
_companyServiceUU( 7
.UU7 8
GetCompanyByIdAsyncUU8 K
(UUK L
idUUL N
)UUN O
;UUO P
ifVV 
(VV 
existingCompanyVV 
==VV  "
nullVV# '
)VV' (
{WW 
returnXX 
NotFoundXX 
(XX  
)XX  !
;XX! "
}YY 
returnZZ 
OkZZ 
(ZZ 
existingCompanyZZ %
)ZZ% &
;ZZ& '
}[[ 	
}\\ 
}]] Î
zD:\Fontys\2025-2026\Semester 3.1\Individueel project\Eventary\Eventary-API\Eventary-API\Controllers\EmployeesController.cs
	namespace 	
Eventary_API
 
. 
Controllers "
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class 
EmployeesController $
:% &

Controller' 1
{ 
private 
readonly 
EmployeeService (
_employeeService) 9
;9 :
public 
EmployeesController "
(" #
EmployeeService# 2
employeeService3 B
)B C
{ 	
_employeeService 
= 
employeeService .
;. /
} 	
[ 	
HttpGet	 
] 
[ 	 
ProducesResponseType	 
< 
List "
<" #
EmployeeDto# .
>. /
>/ 0
(0 1
StatusCodes1 <
.< =
Status200OK= H
)H I
]I J
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status400BadRequest* =
)= >
]> ?
public 
async 
Task 
< 
IEnumerable %
<% &
EmployeeDto& 1
>1 2
>2 3 
GetAllEmployeesAsync4 H
(H I
)I J
{ 	
return 
await 
_employeeService )
.) * 
GetAllEmployeesAsync* >
(> ?
)? @
;@ A
} 	
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
< 
EmployeeDto )
>) *
(* +
StatusCodes+ 6
.6 7
Status200OK7 B
)B C
]C D
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status404NotFound* ;
); <
]< =
public   
async   
Task   
<   
IActionResult   '
?  ' (
>  ( ) 
GetEmployeeByIdAsync  * >
(  > ?
long  ? C
id  D F
)  F G
{!! 	
var"" 
employee"" 
="" 
await""  
_employeeService""! 1
.""1 2 
GetEmployeeByIdAsync""2 F
(""F G
id""G I
)""I J
;""J K
if## 
(## 
employee## 
==## 
null##  
)##  !
{$$ 
return%% 
NotFound%% 
(%%  
$str%%  5
)%%5 6
;%%6 7
}&& 
return'' 
Ok'' 
('' 
employee'' 
)'' 
;''  
}(( 	
}<< 
}== †@
vD:\Fontys\2025-2026\Semester 3.1\Individueel project\Eventary\Eventary-API\Eventary-API\Controllers\ItemsController.cs
	namespace 	
Eventary_API
 
. 
Controllers "
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public		 

class		 
ItemsController		  
:		! "
ControllerBase		# 1
{

 
private 
readonly 
ItemService $
_itemService% 1
;1 2
public 
ItemsController 
( 
ItemService *
itemService+ 6
)6 7
{ 	
_itemService 
= 
itemService &
;& '
} 	
[ 	
HttpGet	 
] 
[ 	 
ProducesResponseType	 
< 
List "
<" #
ItemDto# *
>* +
>+ ,
(, -
StatusCodes- 8
.8 9
Status200OK9 D
)D E
]E F
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status400BadRequest* =
)= >
]> ?
public 
async 
Task 
< 
IEnumerable %
<% &
ItemDto& -
>- .
>. /
GetAllItemsAsync0 @
(@ A
)A B
{ 	
return 
await 
_itemService %
.% &
GetAllItemsAsync& 6
(6 7
)7 8
;8 9
} 	
[ 	
HttpGet	 
( 
$str 
, 
Name 
= 
$str  -
)- .
]. /
[ 	 
ProducesResponseType	 
< 
ItemDto %
>% &
(& '
StatusCodes' 2
.2 3
Status200OK3 >
)> ?
]? @
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status404NotFound* ;
); <
]< =
public 
async 
Task 
< 
IActionResult '
>' (
GetItemByIdAsync) 9
(9 :
long: >
id? A
)A B
{ 	
var 
item 
= 
await 
_itemService )
.) *
GetItemByIdAsync* :
(: ;
id; =
)= >
;> ?
if   
(   
item   
==   
null   
)   
{!! 
return"" 
NotFound"" 
(""  
)""  !
;""! "
}## 
return%% 
Ok%% 
(%% 
item%% 
)%% 
;%% 
}&& 	
[(( 	
HttpPost((	 
](( 
[)) 	 
ProducesResponseType))	 
<)) 
ItemDto)) %
>))% &
())& '
StatusCodes))' 2
.))2 3
Status201Created))3 C
)))C D
]))D E
[** 	 
ProducesResponseType**	 
(** 
StatusCodes** )
.**) *
Status400BadRequest*** =
)**= >
]**> ?
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
AddItemAsync++) 5
(++5 6
[++6 7
FromBody++7 ?
]++? @
ItemDto++A H
itemDto++I P
)++P Q
{,, 	
if-- 
(-- 
!-- 

ModelState-- 
.-- 
IsValid-- #
)--# $
{.. 
return// 

BadRequest// !
(//! "

ModelState//" ,
)//, -
;//- .
}00 
var22 
	addedItem22 
=22 
await22 !
_itemService22" .
.22. /
AddItemAsync22/ ;
(22; <
itemDto22< C
)22C D
;22D E
if44 
(44 
	addedItem44 
.44 
Id44 
<=44 
$num44  !
)44! "
{55 
return66 

BadRequest66 !
(66! "
$str66" J
)66J K
;66K L
}77 
return99 
CreatedAtAction99 "
(99" #
$str99# 0
,990 1
new992 5
{996 7
id998 :
=99; <
	addedItem99= F
.99F G
Id99G I
}99J K
,99K L
	addedItem99M V
)99V W
;99W X
}:: 	
[== 	
HttpPut==	 
(== 
$str== 
)== 
]== 
[>> 	 
ProducesResponseType>>	 
(>> 
StatusCodes>> )
.>>) *
Status200OK>>* 5
)>>5 6
]>>6 7
[?? 	 
ProducesResponseType??	 
(?? 
StatusCodes?? )
.??) *
Status400BadRequest??* =
)??= >
]??> ?
[@@ 	 
ProducesResponseType@@	 
(@@ 
StatusCodes@@ )
.@@) *
Status404NotFound@@* ;
)@@; <
]@@< =
publicAA 
asyncAA 
TaskAA 
<AA 
IActionResultAA '
>AA' (
UpdateItemAsyncAA) 8
(AA8 9
longAA9 =
idAA> @
,AA@ A
[AAB C
FromBodyAAC K
]AAK L
ItemDtoAAM T
itemDtoAAU \
)AA\ ]
{BB 	
ifCC 
(CC 
!CC 

ModelStateCC 
.CC 
IsValidCC #
)CC# $
{DD 
returnEE 

BadRequestEE !
(EE! "

ModelStateEE" ,
)EE, -
;EE- .
}FF 
varHH 
existingItemHH 
=HH 
awaitHH $
_itemServiceHH% 1
.HH1 2
GetItemByIdAsyncHH2 B
(HHB C
idHHC E
)HHE F
;HHF G
ifII 
(II 
existingItemII 
==II 
nullII  $
)II$ %
{JJ 
returnKK 
NotFoundKK 
(KK  
$strKK  1
)KK1 2
;KK2 3
}LL 
itemDtoNN 
.NN 
IdNN 
=NN 
idNN 
;NN 
awaitOO 
_itemServiceOO 
.OO 
UpdateItemAsyncOO .
(OO. /
itemDtoOO/ 6
)OO6 7
;OO7 8
returnPP 
OkPP 
(PP 
)PP 
;PP 
}QQ 	
[UU 	

HttpDeleteUU	 
]UU 
[VV 	
RouteVV	 
(VV 
$strVV 
)VV 
]VV 
[WW 	 
ProducesResponseTypeWW	 
(WW 
StatusCodesWW )
.WW) *
Status200OKWW* 5
)WW5 6
]WW6 7
[XX 	 
ProducesResponseTypeXX	 
(XX 
StatusCodesXX )
.XX) *
Status404NotFoundXX* ;
)XX; <
]XX< =
publicYY 
asyncYY 
TaskYY 
<YY 
IActionResultYY '
>YY' (
DeleteItemAsyncYY) 8
(YY8 9
longYY9 =
idYY> @
)YY@ A
{ZZ 	
var[[ 
existingItem[[ 
=[[ 
await[[ $
_itemService[[% 1
.[[1 2
GetItemByIdAsync[[2 B
([[B C
id[[C E
)[[E F
;[[F G
if\\ 
(\\ 
existingItem\\ 
==\\ 
null\\  $
)\\$ %
{]] 
return^^ 
NotFound^^ 
(^^  
$str^^  1
)^^1 2
;^^2 3
}__ 
awaitaa 
_itemServiceaa 
.aa 
DeleteItemAsyncaa .
(aa. /
idaa/ 1
)aa1 2
;aa2 3
returnbb 
Okbb 
(bb 
)bb 
;bb 
}cc 	
}gg 
}hh ‚>
vD:\Fontys\2025-2026\Semester 3.1\Individueel project\Eventary\Eventary-API\Eventary-API\Controllers\OrderController.cs
	namespace 	
Eventary_API
 
. 
Controllers "
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public		 

class		 
OrderController		  
:		! "

Controller		# -
{

 
private 
readonly 
OrderService %
_orderService& 3
;3 4
public 
OrderController 
( 
OrderService +
orderService, 8
)8 9
{ 	
_orderService 
= 
orderService (
;( )
} 	
[ 	
HttpGet	 
] 
[ 	 
ProducesResponseType	 
< 
List "
<" #
OrderDto# +
>+ ,
>, -
(- .
StatusCodes. 9
.9 :
Status200OK: E
)E F
]F G
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status400BadRequest* =
)= >
]> ?
public 
async 
Task 
< 
IEnumerable %
<% &
OrderDto& .
>. /
>/ 0
GetAllOrdersAsync1 B
(B C
)C D
{ 	
return 
await 
_orderService &
.& '
GetAllOrdersAsync' 8
(8 9
)9 :
;: ;
} 	
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
< 
OrderDto &
>& '
(' (
StatusCodes( 3
.3 4
Status200OK4 ?
)? @
]@ A
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status404NotFound* ;
); <
]< =
public 
async 
Task 
< 
IActionResult '
>' (
GetOrderByIdAsync) :
(: ;
long; ?
id@ B
)B C
{ 	
var   
order   
=   
await   
_orderService   +
.  + ,
GetOrderByIdAsync  , =
(  = >
id  > @
)  @ A
;  A B
if!! 
(!! 
order!! 
==!! 
null!! 
)!! 
{"" 
return## 
NotFound## 
(##  
$str##  2
)##2 3
;##3 4
}$$ 
return&& 
Ok&& 
(&& 
order&& 
)&& 
;&& 
}'' 	
[** 	
HttpPost**	 
]** 
[++ 	 
ProducesResponseType++	 
<++ 
OrderDto++ &
>++& '
(++' (
StatusCodes++( 3
.++3 4
Status201Created++4 D
)++D E
]++E F
[,, 	 
ProducesResponseType,,	 
(,, 
StatusCodes,, )
.,,) *
Status400BadRequest,,* =
),,= >
],,> ?
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (
AddOrderAsync--) 6
(--6 7
[--7 8
FromBody--8 @
]--@ A
OrderDto--B J
orderDto--K S
)--S T
{.. 	
if// 
(// 
!// 

ModelState// 
.// 
IsValid// #
)//# $
{00 
return11 

BadRequest11 !
(11! "

ModelState11" ,
)11, -
;11- .
}22 
await44 
_orderService44 
.44  
AddOrderAsync44  -
(44- .
orderDto44. 6
)446 7
;447 8
return55 
CreatedAtAction55 "
(55" #
nameof55# )
(55) *
GetOrderByIdAsync55* ;
)55; <
,55< =
new55> A
{55B C
id55D F
=55G H
orderDto55I Q
.55Q R
Id55R T
}55U V
,55V W
orderDto55X `
)55` a
;55a b
}66 	
[88 	
HttpPut88	 
]88 
[99 	 
ProducesResponseType99	 
(99 
StatusCodes99 )
.99) *
Status200OK99* 5
)995 6
]996 7
[:: 	 
ProducesResponseType::	 
(:: 
StatusCodes:: )
.::) *
Status400BadRequest::* =
)::= >
]::> ?
[;; 	 
ProducesResponseType;;	 
(;; 
StatusCodes;; )
.;;) *
Status404NotFound;;* ;
);;; <
];;< =
[<< 	 
ProducesResponseType<<	 
(<< 
StatusCodes<< )
.<<) *(
Status500InternalServerError<<* F
)<<F G
]<<G H
public== 
async== 
Task== 
<== 
IActionResult== '
>==' (
UpdateOrderAsync==) 9
(==9 :
OrderDto==: B
orderDto==C K
)==K L
{>> 	
if?? 
(?? 
!?? 

ModelState?? 
.?? 
IsValid?? #
)??# $
{@@ 
returnAA 

BadRequestAA !
(AA! "

ModelStateAA" ,
)AA, -
;AA- .
}BB 
varCC 
existingOrderCC 
=CC 
awaitCC  %
_orderServiceCC& 3
.CC3 4
GetOrderByIdAsyncCC4 E
(CCE F
orderDtoCCF N
.CCN O
IdCCO Q
)CCQ R
;CCR S
ifDD 
(DD 
existingOrderDD 
==DD  
nullDD! %
)DD% &
{EE 
returnFF 
NotFoundFF 
(FF  
$strFF  2
)FF2 3
;FF3 4
}GG 
awaitHH 
_orderServiceHH 
.HH  
UpdateOrderAsyncHH  0
(HH0 1
orderDtoHH1 9
)HH9 :
;HH: ;
returnII 
OkII 
(II 
)II 
;II 
}JJ 	
[LL 	

HttpDeleteLL	 
]LL 
[MM 	
RouteMM	 
(MM 
$strMM 
)MM 
]MM 
[NN 	 
ProducesResponseTypeNN	 
(NN 
StatusCodesNN )
.NN) *
Status200OKNN* 5
)NN5 6
]NN6 7
[OO 	 
ProducesResponseTypeOO	 
(OO 
StatusCodesOO )
.OO) *
Status404NotFoundOO* ;
)OO; <
]OO< =
publicPP 
asyncPP 
TaskPP 
<PP 
IActionResultPP '
>PP' (
DeleteOrderAsyncPP) 9
(PP9 :
longPP: >
idPP? A
)PPA B
{QQ 	
varRR 
existingOrderRR 
=RR 
awaitRR  %
_orderServiceRR& 3
.RR3 4
GetOrderByIdAsyncRR4 E
(RRE F
idRRF H
)RRH I
;RRI J
ifSS 
(SS 
existingOrderSS 
==SS  
nullSS! %
)SS% &
{TT 
returnUU 
NotFoundUU 
(UU  
$strUU  2
)UU2 3
;UU3 4
}VV 
awaitXX 
_orderServiceXX 
.XX  
DeleteOrderAsyncXX  0
(XX0 1
idXX1 3
)XX3 4
;XX4 5
returnYY 
OkYY 
(YY 
)YY 
;YY 
}ZZ 	
}\\ 
}]] Û1
bD:\Fontys\2025-2026\Semester 3.1\Individueel project\Eventary\Eventary-API\Eventary-API\Program.cs
	namespace		 	
Eventary_API		
 
{

 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
var 
builder 
= 
WebApplication (
.( )
CreateBuilder) 6
(6 7
args7 ;
); <
;< =
var 
connectionString  
=! "
builder# *
.* +
Configuration+ 8
.8 9
GetConnectionString9 L
(L M
$strM S
)S T
;T U
builder 
. 
Services 
. 
AddDbContext )
<) *
AppDbContext* 6
>6 7
(7 8
options8 ?
=>@ B
options 
. 
UseMySql !
(! "
connectionString" 2
,2 3
ServerVersion4 A
.A B

AutoDetectB L
(L M
connectionStringM ]
)] ^
)^ _
)_ `
;` a
builder 
. 
Services 
. 
	AddScoped &
<& '
IEmployeeRepository' :
,: ;
EmployeeRepository< N
>N O
(O P
)P Q
;Q R
builder 
. 
Services 
. 
	AddScoped &
<& '
EmployeeService' 6
>6 7
(7 8
)8 9
;9 :
builder 
. 
Services 
. 
	AddScoped &
<& '
IItemRepository' 6
,6 7
ItemRepository8 F
>F G
(G H
)H I
;I J
builder 
. 
Services 
. 
	AddScoped &
<& '
ItemService' 2
>2 3
(3 4
)4 5
;5 6
builder 
. 
Services 
. 
	AddScoped &
<& '
ICategoryRepository' :
,: ;
CategoryRepository< N
>N O
(O P
)P Q
;Q R
builder 
. 
Services 
. 
	AddScoped &
<& '
CategoryService' 6
>6 7
(7 8
)8 9
;9 :
builder 
. 
Services 
. 
	AddScoped &
<& '
IOrderRepository' 7
,7 8
OrderRepository9 H
>H I
(I J
)J K
;K L
builder 
. 
Services 
. 
	AddScoped &
<& '
OrderService' 3
>3 4
(4 5
)5 6
;6 7
builder 
. 
Services 
. 
	AddScoped &
<& '
ICompanyRepository' 9
,9 :
CompanyRepository; L
>L M
(M N
)N O
;O P
builder 
. 
Services 
. 
	AddScoped &
<& '
CompanyService' 5
>5 6
(6 7
)7 8
;8 9
builder!! 
.!! 
Services!! 
.!! 
AddCors!! $
(!!$ %
options!!% ,
=>!!- /
{"" 
options## 
.## 
	AddPolicy## !
(##! "
$str##" *
,##* +
policy##, 2
=>##3 5
{$$ 
policy%% 
.%% 
WithOrigins%% &
(%%& '
$str&& m
,&&m n
$str'' /
,''/ 0
$str(( /
,((/ 0
$str)) /
,))/ 0
$str** 3
)++ 
.,, 
AllowAnyHeader,, #
(,,# $
),,$ %
.-- 
AllowAnyMethod-- #
(--# $
)--$ %
;--% &
}.. 
).. 
;.. 
}// 
)// 
;// 
builder11 
.11 
Services11 
.11 
AddControllers11 +
(11+ ,
)11, -
;11- .
builder22 
.22 
Services22 
.22 #
AddEndpointsApiExplorer22 4
(224 5
)225 6
;226 7
builder33 
.33 
Services33 
.33 
AddSwaggerGen33 *
(33* +
)33+ ,
;33, -
var55 
app55 
=55 
builder55 
.55 
Build55 #
(55# $
)55$ %
;55% &
if77 
(77 
app77 
.77 
Environment77 
.77  
IsDevelopment77  -
(77- .
)77. /
)77/ 0
{88 
app99 
.99 

UseSwagger99 
(99 
)99  
;99  !
app:: 
.:: 
UseSwaggerUI::  
(::  !
c::! "
=>::# %
{;; 
c<< 
.<< 
SwaggerEndpoint<< %
(<<% &
$str<<& @
,<<@ A
$str<<B J
)<<J K
;<<K L
}== 
)== 
;== 
}>> 
app@@ 
.@@ 
UseCors@@ 
(@@ 
$str@@  
)@@  !
;@@! "
appBB 
.BB 

UseRoutingBB 
(BB 
)BB 
;BB 
appCC 
.CC 
UseAuthorizationCC  
(CC  !
)CC! "
;CC" #
appDD 
.DD 
MapControllersDD 
(DD 
)DD  
;DD  !
appEE 
.EE 
MapGetEE 
(EE 
$strEE 
,EE 
(EE 
)EE 
=>EE !
$strEE" ;
)EE; <
;EE< =
appGG 
.GG 
RunGG 
(GG 
)GG 
;GG 
}II 	
}JJ 
}KK 