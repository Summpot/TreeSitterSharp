project('tree-sitter', 'c')

incdir = include_directories('src/lib/include')

if host_machine.system() == 'windows'
    morekwargs = {'vs_module_defs': 'tree-sitter.def'}
else
    morekwargs = {}
endif

shared_library('tree-sitter', 
    sources : ['src/lib/src/lib.c'], 
    include_directories : incdir,
    kwargs : morekwargs)