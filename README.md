# n4.net.generics
<a href="http://n4works.com" target="blank"><img align="right" width="256px" height="256px" src="http://n4works.com/imagens/favicon.ico"></a>


[![Build Status](https://travis-ci.org/N4Works/n4.net.generics.svg?branch=master)](https://travis-ci.org/N4Works/n4.net.generics)
[![Build status](https://ci.appveyor.com/api/projects/status/0l96a5ii9jueuuvk?svg=true)](https://ci.appveyor.com/project/tiagor87/n4-net-generics)
[![Coverage Status](https://coveralls.io/repos/github/N4Works/n4.net.generics/badge.svg?branch=master)](https://coveralls.io/github/N4Works/n4.net.generics?branch=master)
[![NuGet](https://img.shields.io/nuget/v/n4.net.generics.svg)](https://www.nuget.org/packages/N4.Net.Generics)


__USAGE:__
​
__*Disposable class:*__

```csharp

public class User : Disposable {
	
	public override BeforeDispose() {
	
	}
}


...

using (var user = new User()) {

}

```

__*BaseModel class:*__

```csharp

public class User: BaseModel {
	public User(string id) {
		this.Id = id;
	}
}

...

using (var user  = new User("id")) {
	repository.findSomethingByUserId(user.Id);
}
```

__*AbstractFactory class:*__

```csharp
public interface IUser {

}

public class User : IUser {

}

...

var factory = new AbstractFactory();
factory.Register<IUser, User>();

var user = factory.Create<IUser>();

...

public interface IProvider {

}

public class Provider : IProvider {

}

public interface IRepository {
	
}

public class Repository : IRepository {
	public Repository(IProvider provider) {
	
	}
}

...

var factory = new AbstractFactory();
factory.Register<IProvider, Provider>();
factory.Register<IRepository, Repository>(typeof(IProvider));

var repository = factory.Create<IRepository>();

```