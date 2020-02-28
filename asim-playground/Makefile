TOP = ..
RUNTIME_DIR = $(TOP)/../runtime
OPENSSL_INCLUDE_DIR = /usr/local/opt/openssl/include

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

.PHONY: test
test:
	dotnet test \
		--framework netcoreapp3.1 \
		$(TOP)/src/Compilers/CSharp/Test/Symbol/Microsoft.CodeAnalysis.CSharp.Symbol.UnitTests.csproj \
		--filter Microsoft.CodeAnalysis.CSharp.UnitTests.Symbols.AbstractStaticInterfaceMemberTests