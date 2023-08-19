project('tree-sitter-cpp', 'c')

incdir = include_directories('src/src')

shared_library('tree-sitter-cpp',
            sources : ['src/src/parser.c', 'src/src/scanner.c'], 
            include_directories : incdir)