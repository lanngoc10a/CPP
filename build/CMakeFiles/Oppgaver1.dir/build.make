# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.22

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:

#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:

# Disable VCS-based implicit rules.
% : %,v

# Disable VCS-based implicit rules.
% : RCS/%

# Disable VCS-based implicit rules.
% : RCS/%,v

# Disable VCS-based implicit rules.
% : SCCS/s.%

# Disable VCS-based implicit rules.
% : s.%

.SUFFIXES: .hpux_make_needs_suffix_list

# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

#Suppress display of executed commands.
$(VERBOSE).SILENT:

# A target that is always out of date.
cmake_force:
.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /usr/local/Cellar/cmake/3.22.1/bin/cmake

# The command to remove a file.
RM = /usr/local/Cellar/cmake/3.22.1/bin/cmake -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /Users/lan/Downloads/Github/CPP

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /Users/lan/Downloads/Github/CPP/build

# Include any dependencies generated for this target.
include CMakeFiles/Oppgaver1.dir/depend.make
# Include any dependencies generated by the compiler for this target.
include CMakeFiles/Oppgaver1.dir/compiler_depend.make

# Include the progress variables for this target.
include CMakeFiles/Oppgaver1.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/Oppgaver1.dir/flags.make

CMakeFiles/Oppgaver1.dir/main.cpp.o: CMakeFiles/Oppgaver1.dir/flags.make
CMakeFiles/Oppgaver1.dir/main.cpp.o: ../main.cpp
CMakeFiles/Oppgaver1.dir/main.cpp.o: CMakeFiles/Oppgaver1.dir/compiler_depend.ts
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/Users/lan/Downloads/Github/CPP/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/Oppgaver1.dir/main.cpp.o"
	/Library/Developer/CommandLineTools/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -MD -MT CMakeFiles/Oppgaver1.dir/main.cpp.o -MF CMakeFiles/Oppgaver1.dir/main.cpp.o.d -o CMakeFiles/Oppgaver1.dir/main.cpp.o -c /Users/lan/Downloads/Github/CPP/main.cpp

CMakeFiles/Oppgaver1.dir/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/Oppgaver1.dir/main.cpp.i"
	/Library/Developer/CommandLineTools/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /Users/lan/Downloads/Github/CPP/main.cpp > CMakeFiles/Oppgaver1.dir/main.cpp.i

CMakeFiles/Oppgaver1.dir/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/Oppgaver1.dir/main.cpp.s"
	/Library/Developer/CommandLineTools/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /Users/lan/Downloads/Github/CPP/main.cpp -o CMakeFiles/Oppgaver1.dir/main.cpp.s

# Object files for target Oppgaver1
Oppgaver1_OBJECTS = \
"CMakeFiles/Oppgaver1.dir/main.cpp.o"

# External object files for target Oppgaver1
Oppgaver1_EXTERNAL_OBJECTS =

Oppgaver1: CMakeFiles/Oppgaver1.dir/main.cpp.o
Oppgaver1: CMakeFiles/Oppgaver1.dir/build.make
Oppgaver1: CMakeFiles/Oppgaver1.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/Users/lan/Downloads/Github/CPP/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable Oppgaver1"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/Oppgaver1.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/Oppgaver1.dir/build: Oppgaver1
.PHONY : CMakeFiles/Oppgaver1.dir/build

CMakeFiles/Oppgaver1.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/Oppgaver1.dir/cmake_clean.cmake
.PHONY : CMakeFiles/Oppgaver1.dir/clean

CMakeFiles/Oppgaver1.dir/depend:
	cd /Users/lan/Downloads/Github/CPP/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /Users/lan/Downloads/Github/CPP /Users/lan/Downloads/Github/CPP /Users/lan/Downloads/Github/CPP/build /Users/lan/Downloads/Github/CPP/build /Users/lan/Downloads/Github/CPP/build/CMakeFiles/Oppgaver1.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/Oppgaver1.dir/depend

