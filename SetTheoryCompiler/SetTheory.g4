grammar SetTheory;

/*
 * Parser Rules
 */
 expression :
		set
		| VARIABLE
		| VARIABLE '=' expression
		| CREATION_FUNCTION '(' NUMBER ',' NUMBER ',' NUMBER ')'
		| BINARY_FUNCTION '(' expression ',' expression ')'
		| UNARY_FUNCTION '(' expression ')'
		| ELEMENT_FUNCTION '(' expression ',' NUMBER ')'
		;

set :
      OPEN_BRACKET   (NUMBER | (NUMBER ',' NUMBER)*)    CLOSE_BRACKET
      ;

/*
 * Lexer Rules
 */

OPEN_BRACKET		: '[' ;
CLOSE_BRACKET		: ']' ;
NUMBER				: [0-9]+ ;
VARIABLE			: [a-z]+ ;
CREATION_FUNCTION	: 'set' ;
BINARY_FUNCTION		: 'int'|'uni'|'ext' ;
UNARY_FUNCTION		: 'max'|'min'|'len'|'avg' ;
ELEMENT_FUNCTION	: 'add'|'del' ;

WS					: ' ' -> channel(HIDDEN) ;
