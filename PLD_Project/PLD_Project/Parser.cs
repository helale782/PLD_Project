
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

	[Serializable()]
	public class SymbolException : System.Exception
	{
		public SymbolException(string message) : base(message)
		{
		}

		public SymbolException(string message,
			Exception inner) : base(message, inner)
		{
		}

		protected SymbolException(SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}

	}

	[Serializable()]
	public class RuleException : System.Exception
	{

		public RuleException(string message) : base(message)
		{
		}

		public RuleException(string message,
							 Exception inner) : base(message, inner)
		{
		}

		protected RuleException(SerializationInfo info,
								StreamingContext context) : base(info, context)
		{
		}

	}

	enum SymbolConstants : int
	{
		SYMBOL_EOF = 0, // (EOF)
		SYMBOL_ERROR = 1, // (Error)
		SYMBOL_WHITESPACE = 2, // Whitespace
		SYMBOL_MINUS = 3, // '-'
		SYMBOL_LPAREN = 4, // '('
		SYMBOL_RPAREN = 5, // ')'
		SYMBOL_TIMES = 6, // '*'
		SYMBOL_COMMA = 7, // ','
		SYMBOL_DIV = 8, // '/'
		SYMBOL_COLON = 9, // ':'
		SYMBOL_COLONEQ = 10, // ':='
		SYMBOL_SEMI = 11, // ';'
		SYMBOL_PLUS = 12, // '+'
		SYMBOL_LT = 13, // '<'
		SYMBOL_LTEQ = 14, // '<='
		SYMBOL_LTGT = 15, // '<>'
		SYMBOL_EQ = 16, // '='
		SYMBOL_EQEQ = 17, // '=='
		SYMBOL_GT = 18, // '>'
		SYMBOL_GTEQ = 19, // '>='
		SYMBOL_BEGIN = 20, // begin
		SYMBOL_BOOLEAN = 21, // boolean
		SYMBOL_CASE = 22, // case
		SYMBOL_CHAR = 23, // char
		SYMBOL_CONST = 24, // const
		SYMBOL_DO = 25, // do
		SYMBOL_ELSE = 26, // else
		SYMBOL_END = 27, // end
		SYMBOL_FOR = 28, // for
		SYMBOL_FUNCTION = 29, // function
		SYMBOL_IDENTIFIER = 30, // Identifier
		SYMBOL_IF = 31, // if
		SYMBOL_INTEGER = 32, // integer
		SYMBOL_OF = 33, // of
		SYMBOL_PROCEDURE = 34, // procedure
		SYMBOL_REAL = 35, // real
		SYMBOL_REPEAT = 36, // repeat
		SYMBOL_RESULT = 37, // Result
		SYMBOL_STRING = 38, // string
		SYMBOL_STRINGLITERAL = 39, // StringLiteral
		SYMBOL_THEN = 40, // then
		SYMBOL_TO = 41, // to
		SYMBOL_UNTIL = 42, // until
		SYMBOL_VAR = 43, // var
		SYMBOL_WHILE = 44, // while
		SYMBOL_ADD_EXPR = 45, // <add_expr>
		SYMBOL_ASSIGN = 46, // <assign>
		SYMBOL_CASE_ITEM = 47, // <case_item>
		SYMBOL_CASE_STMT = 48, // <case_stmt>
		SYMBOL_COMPOUND_STMT = 49, // <compound_stmt>
		SYMBOL_CONDITION = 50, // <condition>
		SYMBOL_CONST_DECL = 51, // <const_decl>
		SYMBOL_CONST_DEF = 52, // <const_def>
		SYMBOL_CONST_NAME = 53, // <const_name>
		SYMBOL_CONST_VALUE = 54, // <const_value>
		SYMBOL_EXPR = 55, // <expr>
		SYMBOL_FOR_LOOP = 56, // <for_loop>
		SYMBOL_FUNCTION2 = 57, // <function>
		SYMBOL_FUNCTION_BODY = 58, // <function_body>
		SYMBOL_FUNCTION_NAME = 59, // <function_name>
		SYMBOL_ID_LIST = 60, // <id_list>
		SYMBOL_IF_STMT = 61, // <if_stmt>
		SYMBOL_LOOP = 62, // <loop>
		SYMBOL_MUL_EXPR = 63, // <mul_expr>
		SYMBOL_PARAMETER = 64, // <parameter>
		SYMBOL_PARAMETER_LST = 65, // <parameter_lst>
		SYMBOL_PRE_EXPR = 66, // <pre_expr>
		SYMBOL_PROC_BODY = 67, // <proc_body>
		SYMBOL_PROC_NAME = 68, // <proc_name>
		SYMBOL_PROCEDURE2 = 69, // <procedure>
		SYMBOL_PROGRAM = 70, // <Program>
		SYMBOL_REL_EXPR = 71, // <rel_expr>
		SYMBOL_REPEAT2 = 72, // <repeat>
		SYMBOL_RETURN_TYPE = 73, // <return_type>
		SYMBOL_STMT = 74, // <stmt>
		SYMBOL_STMT_LST = 75, // <stmt_lst>
		SYMBOL_TYPE = 76, // <type>
		SYMBOL_VAL = 77, // <val>
		SYMBOL_VAR_DECL = 78, // <var_decl>
		SYMBOL_WHILE_LOOP = 79  // <while_loop>
	};

	enum RuleConstants : int
	{
		RULE_TYPE_INTEGER = 0, // <type> ::= integer
		RULE_TYPE_REAL = 1, // <type> ::= real
		RULE_TYPE_BOOLEAN = 2, // <type> ::= boolean
		RULE_TYPE_CHAR = 3, // <type> ::= char
		RULE_TYPE_STRING = 4, // <type> ::= string
		RULE_CONST_VALUE_INTEGER = 5, // <const_value> ::= integer
		RULE_CONST_VALUE_REAL = 6, // <const_value> ::= real
		RULE_CONST_VALUE_BOOLEAN = 7, // <const_value> ::= boolean
		RULE_CONST_VALUE_CHAR = 8, // <const_value> ::= char
		RULE_CONST_VALUE_STRINGLITERAL = 9, // <const_value> ::= StringLiteral
		RULE_PROGRAM = 10, // <Program> ::= <stmt_lst>
		RULE_STMT_LST = 11, // <stmt_lst> ::= <stmt>
		RULE_STMT_LST2 = 12, // <stmt_lst> ::= <stmt> <stmt_lst>
		RULE_STMT = 13, // <stmt> ::= <assign>
		RULE_STMT2 = 14, // <stmt> ::= <loop>
		RULE_STMT3 = 15, // <stmt> ::= <condition>
		RULE_STMT4 = 16, // <stmt> ::= <procedure>
		RULE_STMT5 = 17, // <stmt> ::= <function>
		RULE_STMT6 = 18, // <stmt> ::= <compound_stmt>
		RULE_VAR_DECL_VAR_COLON_SEMI = 19, // <var_decl> ::= var <id_list> ':' <type> ';'
		RULE_VAR_DECL_VAR_COLON_SEMI2 = 20, // <var_decl> ::= var <id_list> ':' <type> ';' <var_decl>
		RULE_ID_LIST_IDENTIFIER = 21, // <id_list> ::= Identifier
		RULE_ID_LIST_IDENTIFIER_COMMA = 22, // <id_list> ::= Identifier ',' <id_list>
		RULE_CONST_DECL_CONST_SEMI = 23, // <const_decl> ::= const <const_def> ';'
		RULE_CONST_DECL_CONST_SEMI2 = 24, // <const_decl> ::= const <const_def> ';' <const_decl>
		RULE_CONST_DEF_EQ = 25, // <const_def> ::= <const_name> '=' <const_value>
		RULE_CONST_DEF_COLON_EQ = 26, // <const_def> ::= <const_name> ':' <type> '=' <const_value>
		RULE_CONST_NAME_IDENTIFIER = 27, // <const_name> ::= Identifier
		RULE_ASSIGN_IDENTIFIER_COLONEQ_SEMI = 28, // <assign> ::= Identifier ':=' <expr> ';'
		RULE_EXPR = 29, // <expr> ::= <rel_expr>
		RULE_COMPOUND_STMT_BEGIN_END = 30, // <compound_stmt> ::= begin <stmt_lst> end
		RULE_COMPOUND_STMT_BEGIN_END_SEMI = 31, // <compound_stmt> ::= begin <stmt_lst> end ';'
		RULE_LOOP = 32, // <loop> ::= <for_loop>
		RULE_LOOP2 = 33, // <loop> ::= <while_loop>
		RULE_LOOP3 = 34, // <loop> ::= <repeat>
		RULE_FOR_LOOP_FOR_TO_DO_SEMI = 35, // <for_loop> ::= for <assign> to <val> do <stmt_lst> ';'
		RULE_WHILE_LOOP_WHILE_DO_SEMI = 36, // <while_loop> ::= while <rel_expr> do <stmt_lst> ';'
		RULE_REPEAT_REPEAT_UNTIL = 37, // <repeat> ::= repeat <stmt_lst> until <rel_expr>
		RULE_CONDITION = 38, // <condition> ::= <if_stmt>
		RULE_CONDITION2 = 39, // <condition> ::= <case_stmt>
		RULE_IF_STMT_IF_THEN = 40, // <if_stmt> ::= if <rel_expr> then <stmt_lst>
		RULE_IF_STMT_IF_THEN_ELSE = 41, // <if_stmt> ::= if <rel_expr> then <stmt_lst> else <stmt_lst>
		RULE_CASE_STMT_CASE_OF = 42, // <case_stmt> ::= case <expr> of <case_item>
		RULE_CASE_STMT_CASE_OF_SEMI_END = 43, // <case_stmt> ::= case <expr> of <case_item> ';' <case_item> end
		RULE_CASE_ITEM_COLON = 44, // <case_item> ::= <val> ':' <stmt_lst>
		RULE_CASE_ITEM_ELSE_COLON = 45, // <case_item> ::= else ':' <stmt_lst>
		RULE_FUNCTION_FUNCTION_LPAREN_RPAREN_COLON_SEMI_BEGIN_END_SEMI = 46, // <function> ::= function <function_name> '(' <parameter_lst> ')' ':' <return_type> ';' begin <function_body> end ';'
		RULE_PARAMETER_LST_SEMI = 47, // <parameter_lst> ::= <parameter> ';'
		RULE_PARAMETER_LST_SEMI2 = 48, // <parameter_lst> ::= <parameter> ';' <parameter_lst>
		RULE_PARAMETER_IDENTIFIER_COLON = 49, // <parameter> ::= Identifier ':' <type>
		RULE_PARAMETER_VAR_IDENTIFIER_COLON = 50, // <parameter> ::= var Identifier ':' <type>
		RULE_PARAMETER_CONST_IDENTIFIER_COLON = 51, // <parameter> ::= const Identifier ':' <type>
		RULE_FUNCTION_NAME_IDENTIFIER = 52, // <function_name> ::= Identifier
		RULE_RETURN_TYPE = 53, // <return_type> ::= <type>
		RULE_FUNCTION_BODY = 54, // <function_body> ::= <stmt_lst>
		RULE_FUNCTION_BODY_RESULT_COLONEQ_SEMI = 55, // <function_body> ::= <stmt_lst> Result ':=' <expr> ';'
		RULE_PROCEDURE_PROCEDURE_LPAREN_RPAREN_SEMI_BEGIN_END_SEMI = 56, // <procedure> ::= procedure <proc_name> '(' <parameter_lst> ')' ';' begin <proc_body> end ';'
		RULE_PROC_NAME_IDENTIFIER = 57, // <proc_name> ::= Identifier
		RULE_PROC_BODY = 58, // <proc_body> ::= <stmt_lst>
		RULE_REL_EXPR_GT = 59, // <rel_expr> ::= <rel_expr> '>' <add_expr>
		RULE_REL_EXPR_LT = 60, // <rel_expr> ::= <rel_expr> '<' <add_expr>
		RULE_REL_EXPR_LTEQ = 61, // <rel_expr> ::= <rel_expr> '<=' <add_expr>
		RULE_REL_EXPR_GTEQ = 62, // <rel_expr> ::= <rel_expr> '>=' <add_expr>
		RULE_REL_EXPR_EQEQ = 63, // <rel_expr> ::= <rel_expr> '==' <add_expr>
		RULE_REL_EXPR_LTGT = 64, // <rel_expr> ::= <rel_expr> '<>' <add_expr>
		RULE_REL_EXPR = 65, // <rel_expr> ::= <add_expr>
		RULE_ADD_EXPR_PLUS = 66, // <add_expr> ::= <add_expr> '+' <mul_expr>
		RULE_ADD_EXPR_MINUS = 67, // <add_expr> ::= <add_expr> '-' <mul_expr>
		RULE_ADD_EXPR = 68, // <add_expr> ::= <mul_expr>
		RULE_MUL_EXPR_TIMES = 69, // <mul_expr> ::= <mul_expr> '*' <pre_expr>
		RULE_MUL_EXPR_DIV = 70, // <mul_expr> ::= <mul_expr> '/' <pre_expr>
		RULE_MUL_EXPR = 71, // <mul_expr> ::= <pre_expr>
		RULE_PRE_EXPR_MINUS = 72, // <pre_expr> ::= '-' <val>
		RULE_PRE_EXPR = 73, // <pre_expr> ::= <val>
		RULE_VAL_IDENTIFIER = 74, // <val> ::= Identifier
		RULE_VAL_INTEGER = 75, // <val> ::= integer
		RULE_VAL_STRINGLITERAL = 76, // <val> ::= StringLiteral
		RULE_VAL_LPAREN_RPAREN = 77  // <val> ::= '(' <rel_expr> ')'
	};

	public class MyParser
	{
		private LALRParser parser;

		ListBox lst;
		ListBox lst2;
		public MyParser(string filename, ListBox lst, ListBox lst2)
		{
			FileStream stream = new FileStream(filename,
											   FileMode.Open,
											   FileAccess.Read,
											   FileShare.Read);

			this.lst = lst;
			this.lst2 = lst2;

			Init(stream);
			stream.Close();


		}

		public MyParser(string baseName, string resourceName)
		{
			byte[] buffer = ResourceUtil.GetByteArrayResource(
				System.Reflection.Assembly.GetExecutingAssembly(),
				baseName,
				resourceName);
			MemoryStream stream = new MemoryStream(buffer);
			Init(stream);
			stream.Close();
		}

		public MyParser(Stream stream)
		{
			Init(stream);
		}

		private void Init(Stream stream)
		{
			CGTReader reader = new CGTReader(stream);
			parser = reader.CreateNewParser();
			parser.TrimReductions = false;
			parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

			parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
			parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
			parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
		}

		private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
		{
			string info = args.Token.Text + " \t \t" + (SymbolConstants)args.Token.Symbol.Id + "\n";
			lst2.Items.Add(info);
		}

		public void Parse(string source)
		{
			NonterminalToken token = parser.Parse(source);
			if (token != null)
			{
				Object obj = CreateObject(token);
				//todo: Use your object any way you like
			}
		}

		private Object CreateObject(Token token)
		{
			if (token is TerminalToken)
				return CreateObjectFromTerminal((TerminalToken)token);
			else
				return CreateObjectFromNonterminal((NonterminalToken)token);
		}

		private Object CreateObjectFromTerminal(TerminalToken token)
		{
			switch (token.Symbol.Id)
			{
				case (int)SymbolConstants.SYMBOL_EOF:
					//(EOF)
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_ERROR:
					//(Error)
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_WHITESPACE:
					//Whitespace
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_MINUS:
					//'-'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_LPAREN:
					//'('
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_RPAREN:
					//')'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_TIMES:
					//'*'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_COMMA:
					//','
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_DIV:
					//'/'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_COLON:
					//':'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_COLONEQ:
					//':='
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_SEMI:
					//';'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_PLUS:
					//'+'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_LT:
					//'<'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_LTEQ:
					//'<='
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_LTGT:
					//'<>'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_EQ:
					//'='
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_EQEQ:
					//'=='
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_GT:
					//'>'
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_GTEQ:
					//'>='
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_BEGIN:
					//begin
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_BOOLEAN:
					//boolean
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CASE:
					//case
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CHAR:
					//char
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CONST:
					//const
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_DO:
					//do
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_ELSE:
					//else
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_END:
					//end
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_FOR:
					//for
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_FUNCTION:
					//function
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_IDENTIFIER:
					//Identifier
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_IF:
					//if
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_INTEGER:
					//integer
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_OF:
					//of
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_PROCEDURE:
					//procedure
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_REAL:
					//real
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_REPEAT:
					//repeat
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_RESULT:
					//Result
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_STRING:
					//string
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_STRINGLITERAL:
					//StringLiteral
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_THEN:
					//then
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_TO:
					//to
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_UNTIL:
					//until
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_VAR:
					//var
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_WHILE:
					//while
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_ADD_EXPR:
					//<add_expr>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_ASSIGN:
					//<assign>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CASE_ITEM:
					//<case_item>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CASE_STMT:
					//<case_stmt>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_COMPOUND_STMT:
					//<compound_stmt>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CONDITION:
					//<condition>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CONST_DECL:
					//<const_decl>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CONST_DEF:
					//<const_def>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CONST_NAME:
					//<const_name>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_CONST_VALUE:
					//<const_value>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_EXPR:
					//<expr>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_FOR_LOOP:
					//<for_loop>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_FUNCTION2:
					//<function>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_FUNCTION_BODY:
					//<function_body>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_FUNCTION_NAME:
					//<function_name>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_ID_LIST:
					//<id_list>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_IF_STMT:
					//<if_stmt>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_LOOP:
					//<loop>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_MUL_EXPR:
					//<mul_expr>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_PARAMETER:
					//<parameter>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_PARAMETER_LST:
					//<parameter_lst>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_PRE_EXPR:
					//<pre_expr>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_PROC_BODY:
					//<proc_body>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_PROC_NAME:
					//<proc_name>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_PROCEDURE2:
					//<procedure>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_PROGRAM:
					//<Program>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_REL_EXPR:
					//<rel_expr>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_REPEAT2:
					//<repeat>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_RETURN_TYPE:
					//<return_type>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_STMT:
					//<stmt>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_STMT_LST:
					//<stmt_lst>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_TYPE:
					//<type>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_VAL:
					//<val>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_VAR_DECL:
					//<var_decl>
					//todo: Create a new object that corresponds to the symbol
					return null;

				case (int)SymbolConstants.SYMBOL_WHILE_LOOP:
					//<while_loop>
					//todo: Create a new object that corresponds to the symbol
					return null;

			}
			throw new SymbolException("Unknown symbol");
		}

		public Object CreateObjectFromNonterminal(NonterminalToken token)
		{
			switch (token.Rule.Id)
			{
				case (int)RuleConstants.RULE_TYPE_INTEGER:
					//<type> ::= integer
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_TYPE_REAL:
					//<type> ::= real
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_TYPE_BOOLEAN:
					//<type> ::= boolean
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_TYPE_CHAR:
					//<type> ::= char
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_TYPE_STRING:
					//<type> ::= string
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_VALUE_INTEGER:
					//<const_value> ::= integer
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_VALUE_REAL:
					//<const_value> ::= real
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_VALUE_BOOLEAN:
					//<const_value> ::= boolean
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_VALUE_CHAR:
					//<const_value> ::= char
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_VALUE_STRINGLITERAL:
					//<const_value> ::= StringLiteral
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PROGRAM:
					//<Program> ::= <stmt_lst>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_STMT_LST:
					//<stmt_lst> ::= <stmt>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_STMT_LST2:
					//<stmt_lst> ::= <stmt> <stmt_lst>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_STMT:
					//<stmt> ::= <assign>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_STMT2:
					//<stmt> ::= <loop>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_STMT3:
					//<stmt> ::= <condition>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_STMT4:
					//<stmt> ::= <procedure>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_STMT5:
					//<stmt> ::= <function>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_STMT6:
					//<stmt> ::= <compound_stmt>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_VAR_DECL_VAR_COLON_SEMI:
					//<var_decl> ::= var <id_list> ':' <type> ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_VAR_DECL_VAR_COLON_SEMI2:
					//<var_decl> ::= var <id_list> ':' <type> ';' <var_decl>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_ID_LIST_IDENTIFIER:
					//<id_list> ::= Identifier
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_ID_LIST_IDENTIFIER_COMMA:
					//<id_list> ::= Identifier ',' <id_list>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_DECL_CONST_SEMI:
					//<const_decl> ::= const <const_def> ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_DECL_CONST_SEMI2:
					//<const_decl> ::= const <const_def> ';' <const_decl>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_DEF_EQ:
					//<const_def> ::= <const_name> '=' <const_value>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_DEF_COLON_EQ:
					//<const_def> ::= <const_name> ':' <type> '=' <const_value>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONST_NAME_IDENTIFIER:
					//<const_name> ::= Identifier
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_ASSIGN_IDENTIFIER_COLONEQ_SEMI:
					//<assign> ::= Identifier ':=' <expr> ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_EXPR:
					//<expr> ::= <rel_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_COMPOUND_STMT_BEGIN_END:
					//<compound_stmt> ::= begin <stmt_lst> end
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_COMPOUND_STMT_BEGIN_END_SEMI:
					//<compound_stmt> ::= begin <stmt_lst> end ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_LOOP:
					//<loop> ::= <for_loop>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_LOOP2:
					//<loop> ::= <while_loop>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_LOOP3:
					//<loop> ::= <repeat>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_FOR_LOOP_FOR_TO_DO_SEMI:
					//<for_loop> ::= for <assign> to <val> do <stmt_lst> ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_WHILE_LOOP_WHILE_DO_SEMI:
					//<while_loop> ::= while <rel_expr> do <stmt_lst> ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_REPEAT_REPEAT_UNTIL:
					//<repeat> ::= repeat <stmt_lst> until <rel_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONDITION:
					//<condition> ::= <if_stmt>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CONDITION2:
					//<condition> ::= <case_stmt>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_IF_STMT_IF_THEN:
					//<if_stmt> ::= if <rel_expr> then <stmt_lst>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_IF_STMT_IF_THEN_ELSE:
					//<if_stmt> ::= if <rel_expr> then <stmt_lst> else <stmt_lst>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CASE_STMT_CASE_OF:
					//<case_stmt> ::= case <expr> of <case_item>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CASE_STMT_CASE_OF_SEMI_END:
					//<case_stmt> ::= case <expr> of <case_item> ';' <case_item> end
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CASE_ITEM_COLON:
					//<case_item> ::= <val> ':' <stmt_lst>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_CASE_ITEM_ELSE_COLON:
					//<case_item> ::= else ':' <stmt_lst>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_FUNCTION_FUNCTION_LPAREN_RPAREN_COLON_SEMI_BEGIN_END_SEMI:
					//<function> ::= function <function_name> '(' <parameter_lst> ')' ':' <return_type> ';' begin <function_body> end ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PARAMETER_LST_SEMI:
					//<parameter_lst> ::= <parameter> ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PARAMETER_LST_SEMI2:
					//<parameter_lst> ::= <parameter> ';' <parameter_lst>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PARAMETER_IDENTIFIER_COLON:
					//<parameter> ::= Identifier ':' <type>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PARAMETER_VAR_IDENTIFIER_COLON:
					//<parameter> ::= var Identifier ':' <type>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PARAMETER_CONST_IDENTIFIER_COLON:
					//<parameter> ::= const Identifier ':' <type>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_FUNCTION_NAME_IDENTIFIER:
					//<function_name> ::= Identifier
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_RETURN_TYPE:
					//<return_type> ::= <type>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_FUNCTION_BODY:
					//<function_body> ::= <stmt_lst>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_FUNCTION_BODY_RESULT_COLONEQ_SEMI:
					//<function_body> ::= <stmt_lst> Result ':=' <expr> ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PROCEDURE_PROCEDURE_LPAREN_RPAREN_SEMI_BEGIN_END_SEMI:
					//<procedure> ::= procedure <proc_name> '(' <parameter_lst> ')' ';' begin <proc_body> end ';'
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PROC_NAME_IDENTIFIER:
					//<proc_name> ::= Identifier
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PROC_BODY:
					//<proc_body> ::= <stmt_lst>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_REL_EXPR_GT:
					//<rel_expr> ::= <rel_expr> '>' <add_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_REL_EXPR_LT:
					//<rel_expr> ::= <rel_expr> '<' <add_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_REL_EXPR_LTEQ:
					//<rel_expr> ::= <rel_expr> '<=' <add_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_REL_EXPR_GTEQ:
					//<rel_expr> ::= <rel_expr> '>=' <add_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_REL_EXPR_EQEQ:
					//<rel_expr> ::= <rel_expr> '==' <add_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_REL_EXPR_LTGT:
					//<rel_expr> ::= <rel_expr> '<>' <add_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_REL_EXPR:
					//<rel_expr> ::= <add_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_ADD_EXPR_PLUS:
					//<add_expr> ::= <add_expr> '+' <mul_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_ADD_EXPR_MINUS:
					//<add_expr> ::= <add_expr> '-' <mul_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_ADD_EXPR:
					//<add_expr> ::= <mul_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_MUL_EXPR_TIMES:
					//<mul_expr> ::= <mul_expr> '*' <pre_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_MUL_EXPR_DIV:
					//<mul_expr> ::= <mul_expr> '/' <pre_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_MUL_EXPR:
					//<mul_expr> ::= <pre_expr>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PRE_EXPR_MINUS:
					//<pre_expr> ::= '-' <val>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_PRE_EXPR:
					//<pre_expr> ::= <val>
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_VAL_IDENTIFIER:
					//<val> ::= Identifier
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_VAL_INTEGER:
					//<val> ::= integer
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_VAL_STRINGLITERAL:
					//<val> ::= StringLiteral
					//todo: Create a new object using the stored tokens.
					return null;

				case (int)RuleConstants.RULE_VAL_LPAREN_RPAREN:
					//<val> ::= '(' <rel_expr> ')'
					//todo: Create a new object using the stored tokens.
					return null;

			}
			throw new RuleException("Unknown rule");
		}

		private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
		{
			string message = "Token error with input: '" + args.Token.ToString() + "'";
			//todo: Report message to UI?
		}

		private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
		{

			string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "'" + "In line: " + args.UnexpectedToken.Location.LineNr + " and column" + args.UnexpectedToken.Location.ColumnNr;
			lst.Items.Add(message);
			string m2 = "Expected Token: " + args.ExpectedTokens.ToString();
			lst.Items.Add(m2);
			//todo: Report message to UI?
		}

	}
}
