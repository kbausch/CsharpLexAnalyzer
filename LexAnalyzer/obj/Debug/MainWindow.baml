   M S B A M L   `   `   `  ����F  BLexAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LexAnalyzerLexAnalyzer  5   	       LexAnalyzer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LexAnalyzer     5   	     � Title$  
MainWindow��5   	   $	��625��6   $
��1000��6)   .��5	      � $��0,0,-6.4,10q�6   ���	#FFF3EAEA.+�5   
   �� $��Lexical Analyzer��6   $
��Left=�6+   $��	413,0,0,0q�6F   $	��Top=�6Y   $��24(�6q   $��Comic Sans MS)�6   $
��Bold"�6�   �� 5   
   -   5        $��Read Next Token��5   #   $
��Left=�6=   $��58��6X   $��
50,481,0,0q�6d   $	��Top=�6x   $	��235��6�   �� 5   
   -   5        $��	tokentext��5      $
��Left=�6%   $��58��6@   $��339,481,0,0q�6L   $
��Wrap=�6a   $	��Top=�6u   $	��276��6�   $��Tokens will appear here��6�   ���	#FFF9F9F96�   �� 5   
   -   5        $��finaltokentext��5      $
��Left=�6*   $��58��6E   $��695,481,0,0q�6Q   $
��Wrap=�6f   $	��Top=�6z   $	��275��6�   $)��#The identification will appear here��6�   
�������6�   �� 5   
   -   5        $��Pick Lexical Table��5      $
��Left=�6.   $��49��6I   $��
22,238,0,0q�6U   $	��Top=�6i   $	��226��6�   6�   �� 5   
   -   5        $��Pick Token Table��5      $
��Left=�6,   $��
22,315,0,0q�6G   $	��Top=�6[   $	��226��6s   $��54��6   6�   �� 5   
   -   5        $��Pick Text File��5      $
��Left=�6*   $��50��6E   $��
22,395,0,0q�6Q   $	��Top=�6e   $	��226��6}   6�   �� 5   
   -   5        $��LexicalTable��5      $
��Left=�6(   $��75��6C   $��259,227,0,0q�6O   $
��Wrap=�6d   $	��Top=�6x   $	��731��6�   
�������6�   �� 5   
   -   5        $��
TokenTable��5      $
��Left=�6&   $��68��6A   $��259,307,0,0q�6M   $
��Wrap=�6b   $	��Top=�6v   $	��731��6�   
�������6�   �� 5   
   -	   5        $��	TextTable��5      $
��Left=�6%   $��78��6@   $��259,380,0,0q�6L   $
��Wrap=�6a   $	��Top=�6u   $	��731��6�   
�������6�   �� 5   
   $
��Left=�6   $	��178��6/   $��	32,43,0,0q�6<   $
��Wrap=�6O   $	��Top=�6c   $	��968��6{   �� 6�   $���-The purpose of the lexical analyzer is to be able to break down Scheme code character by character to figure out which lexeme each token belongs to. It also decides whether tokens exist or not and provides helpful insight as to what causes those errors.��6�   �� 6�  �� 6�  �� 6�  �� 6�  $!�TO USE THE LEXICAL ANALYZER��6�  �� 6�  �� 6�  $+�%1) Pick A Lexical Table to work with.��6�  �� 6  �� 6&  $)�#2) Pick a Token Table to work with.��6*  �� 6W  �� 6c  $.�(3) Pick a Scheme Text File to work with.��6g  �� 6�  �� 6�  $f�`4) Click on the "Read Next Token" Button to go step by step through each token in the text file.��6�  �� 6  �� 6)  �� 65  $�TO USE ANOTHER TEXT FILE��69  �� 6[  �� 6g  $U�O- Simply just select another Text file and it will start over on that text file��6k  6�  �� 5   
   $
��Left=�6   $��461,465,0,0q�6/   $
��Wrap=�6D   $��Token��6X   $	��Top=�6e   �� 5   
   $
��Left=�6   $��802,465,0,0q�6/   $
��Wrap=�6D   $��Identified As:��6X   $	��Top=�6n   $��72��6�   5      5      