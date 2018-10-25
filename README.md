![](https://user-images.githubusercontent.com/37934048/47516521-47c28780-d8a3-11e8-9068-98b63b6c5bdb.PNG)


# INTRODUCTION

The project which is deployed by me truly supports Digital India movement and I am totally proud for the same. The idea to build RAIL-QR came to my mind when I was in my First Year standing in the long queue for just taking a concession certificate. That day I decided that I’ll surely try re-organizing this system. 

The concept, working and the yield of project is totally simple to understand with a complex back-end part. Basically, the system uses QR code to generate automated concession certificates which can be printed in couple of seconds thus cutting the slack of long queues.

# PROJECT WIREFRAME
![railqr-1](https://user-images.githubusercontent.com/37934048/47517610-5c544f00-d8a6-11e8-920a-183442d7ebe0.jpg)
![rail-qr2](https://user-images.githubusercontent.com/37934048/47517829-016f2780-d8a7-11e8-9513-4cceae6a828f.jpg)

These are the main sections of the RAIL-QR.

## Landing Page -- Contains info that you can check without login
(College website)
- Home Firebase Buttons    
    - Courses     : Giving details about the courses offered at DG Ruparel College
    - About us    : Giving details about what exactly the college is. 
    - Notice Board: A notice board which on hovered shows the recent thing happening in the college and consists of RAIL-QR registraion form

## Registration Form-
- Contains details to be filled by college students exclusively.

## Admin(Back-end)-
- Open Registration
    - Opens up the registrion page so that the students can register and the expire date of this form is 1 month from the day admin           starts.
- Generation-Verification
    - Verifies the details filled up by the students with the aadhar details stored in the college database.
- SAP Crystal Report
    - Dynamically creates graphical reports based on the entries made into database by filling up the form.
- Certificate Generator
    - Once details are verified automated concession certificate is generated based Monthly or Quarterly basis
- Rail-QR QR code generator
    - Once the automated certificate is generated it is converted into QR code and mailed to the repective person.

## Client-
- QR code
    - Brings up the QR code to the scanning center which is scanned using TWedge Software and depending upon the validity of certificate      is generated based on monthly or quaterly basis.
    
## Prerequisites

You will need the following things properly installed on your computer.
* **[Visual Studio 2017(https://visualstudio.microsoft.com/downloads/)**



