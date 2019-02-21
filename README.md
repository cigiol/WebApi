# Firebase Repo For .Net
Repo written for easier use in .net for Firebase database. Published with unit tests


# Example
 **0. Packages you need to install**
 
    Install-Package FireSharp -Version 2.0.4

 **1. Connection information you need to complete**

		
		
        string authentication = "your key";
        string baseurl = "https://yourdb.firebaseio.com/";
        FireRepo<Country> repo;
        

 **2. Simple Connection Test**
 

    bool result = await repo.ConnectionTest();


 **3. Insert Operation**
 

	Guid registerGuid = Guid.NewGuid();
    country = new Country() {
    id = registerGuid,
    Foundation = DateTime.Now.AddYears(-20),
    Name = "Elazığ",
    Population = 580872
    };
    await repo.Add(country, registerGuid);

# Unit Test Result
![enter image description here](https://i.ibb.co/x52rvt9/firebase-testing-result.png)

# Repo Implement Example Result
![enter image description here](https://i.ibb.co/Y0zZWxV/firebase-result.png)
 
