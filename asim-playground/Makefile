TOP = ..
RUNTIME_DIR = $(TOP)/../runtime
OPENSSL_INCLUDE_DIR = /usr/local/opt/openssl/include
RUNTIME_MONO_PATH=$(RUNTIME_DIR)/.dotnet-mono/shared/Microsoft.NETCore.App/5.0.0-alpha.1.20070.4/
SAMPLES = bin/Scratch.exe bin/Numerics.exe

all: roslyn runtime

.PHONY: roslyn
roslyn:
	$(TOP)/eng/build.sh --restore --build --pack

.PHONY: runtime
runtime:
	test -d "$(RUNTIME_DIR)" || git clone https://github.com/partydonk/runtime "$(RUNTIME_DIR)"
	"$(RUNTIME_DIR)/coreclr.sh"
	"$(RUNTIME_DIR)/mono.sh"
	"$(RUNTIME_DIR)/libraries.sh" --cmakeargs -DOPENSSL_INCLUDE_DIR="$(OPENSSL_INCLUDE_DIR)"
	$(MAKE) -C "$(RUNTIME_DIR)/src/mono/netcore" run-sample

.PHONY: restore
restore:
	$(TOP)/restore.sh

.PHONY: build
build:
	$(TOP)/build.sh

.PHONY: test
test:
	dotnet test \
		--framework netcoreapp3.1 \
		$(TOP)/src/Compilers/CSharp/Test/Symbol/Microsoft.CodeAnalysis.CSharp.Symbol.UnitTests.csproj \
		--filter Microsoft.CodeAnalysis.CSharp.UnitTests.Symbols.AbstractStaticInterfaceMemberTests

.PHONY: samples
samples: $(SAMPLES)

bin/%.exe: %.cs
	mkdir -p $(dir $@)
	./csc $< -out:$@
	ikdasm $@ > $(@:.exe=.il)

.PHONY: clean
clean:
	rm -rf bin

run-sample:
	MONO_PATH=$(RUNTIME_MONO_PATH) DYLD_LIBRARY_PATH=$(RUNTIME_MONO_PATH) $(RUNTIME_DIR)/artifacts/obj/mono/OSX.x64.Debug/mono/mini/mono-sgen Scratch.exe 2>&1 | less

