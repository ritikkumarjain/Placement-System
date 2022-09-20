import React, { useEffect, useRef, useState } from 'react';
import { useNavigate } from "react-router-dom";
import Footer from "../../Footer/Footer";
import Header from "../../Header/Header";
import "./StudentView.css";
import ClimbingBoxLoader from "react-spinners/ClimbingBoxLoader";


function CreateStudent() {
    const [name, setName] = useState("");
    const [universityId, setUniversityId] = useState("");
    const [registrationNumber, setRegistrationNumber] = useState("");
    const [semester, setSemester] = useState("");
    const [department, setDepartment] = useState("");
    const [firstSem, setFirstSem] = useState("");
    const [secondSem, setSecondSem] = useState("");
    const [thirdSem, setThirdSem] = useState("");
    const [fourthSem, setFourthSem] = useState("");
    const [fifthSem, setFifthSem] = useState("");
    const [sixthSem, setSixthSem] = useState("");
    const [seventhSem, setSeventhSem] = useState("");
    const [eigthSem, setEigthSem] = useState("");
    const [alertBool, setAlert] = useState(false); 
    const localItem = JSON.parse(localStorage.getItem("user-info"));
    const formRef = useRef(null);
    const navigate = useNavigate();
    const [loading, setLoading] = useState(false);



    useEffect(() => {
        setUniversityId(localItem.university);
    }, [localItem])

    async function HandleSubmit(e) {
        e.preventDefault();
        setLoading(true);


        

        if (!formRef.current?.reportValidity()) {
            alert("Wrong or Unfilled Inputs");
            setLoading(false);
            return;
        }

        const postData = {
            name,
            universityId,
            registrationNumber,
            semester,
            department,
            firstSem: firstSem.toUpperCase(),
            secondSem: secondSem.toUpperCase(),
            thirdSem: thirdSem.toUpperCase(),
            fourthSem: fourthSem.toUpperCase(),
            fifthSem: fifthSem.toUpperCase(),
            sixthSem: sixthSem.toUpperCase(),
            seventhSem: seventhSem.toUpperCase(),
            eigthSem: eigthSem.toUpperCase()
        }

        await fetch("https://localhost:44388/api/Students/CreateStudentsData", {
            method: "POST",
            headers: new Headers({
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }),
            body: JSON.stringify(postData)
        })
            .then(response => response.json())
            .then(data => {
                if (data.status === 404) {
                    alert("Something went wrong");
                    setLoading(false);
                    return;
                }
                if(data)
                {
                    setLoading(false);
                    setAlert(true); 
                    return;
                }
                setLoading(false);
                setAlert(false); 
                
            })
            .catch(error => {
                alert("Error Occured.The data is already created");
                setLoading(false);
                window.location.reload();
            });
    };

   


    return (
        <>
            <Header />
            <div className="student-create-container">
                <form ref={formRef}>
                    <div className="form-group">
                        <h2 className="heading">Enter Details..</h2>
                        <div>
                            <label htmlFor="inputName">Name</label>
                            <input type="text" className="form-control" id="inputName" placeholder="Enter Name" onChange={(e) => setName(e.target.value)} maxLength="30" minLength="3" pattern="^[a-zA-Z]{4,}(?: [a-zA-Z]+){0,2}$" required/>
                        </div>

                        <div className="d-flex row">
                            <div className="form-group col-md-6">
                                <label htmlFor="inputUniverityId" className="col-form-label">UniversityId</label>
                                <input type="text" className="form-control" id="inputUniversityId" placeholder="Enter University Id" value={universityId} disabled />
                            </div>
                            <div className="form-group col-md-6">
                                <label htmlFor="inputRegistrationNumber" className="col-form-label">Registration No.</label>
                                <input type="text" className="form-control" id="inputRegistrationNumber" placeholder="Enter Registration Number" onChange={(e) => setRegistrationNumber(e.target.value)} pattern="^[1-9][0-9]{0,8}$" required/>
                            </div>
                        </div>

                        <div className="d-flex row">
                            <div className="form-group col-md-6">
                                <label htmlFor="inputSemester" className="col-form-label">Semester</label>
                                <select id="inputSemester" className="form-control" onChange={(e) => setSemester(e.target.value)} required>
                                    <option selected disabled>Choose Semester...</option>
                                    <option value="I">I</option>
                                    <option value="II">II</option>
                                    <option value="III">III</option>
                                    <option value="IV">IV</option>
                                    <option value="V">V</option>
                                    <option value="VI">VI</option>
                                    <option value="VII">VII</option>
                                    <option value="VIII">VIII</option>
                                </select>
                            </div>
                            <div className="form-group col-md-6">
                                <label htmlFor="inputDept" className="col-form-label">Department</label>
                                <select id="inputDept" className="form-control" onChange={(e) => setDepartment(e.target.value)} required>
                                    <option selected disabled>Choose Department...</option>
                                    <option value="Computer Science Engineering">Computer Science and Engineering</option>
                                    <option value="Electronics and Telecommunication Engineering">Electronics and Telecommunication Engineering</option>
                                    <option value="Civil Engineering">Civil Engineering</option>
                                    <option value="Chemical Engineering">Chemical Engineering</option>
                                    <option value="Mechanical Engineering">Mechanical Engineering</option>
                                    <option value="Electrical Engineering">Electrical Engineering</option>
                                </select>
                            </div>
                        </div>

                        <div className="d-flex row">
                            <div className="form-group col-md-6">
                                <label htmlFor="inputFirstSem" className="col-form-label">First Semester</label>
                                <input type="text" className="form-control" id="inputFirstSem" placeholder="Enter First Semester CGPA or NA" onChange={(e) => setFirstSem(e.target.value)} pattern="^[1-9]{1}(\.\d{1,2})?$|^NA$|^Na$|^nA$|^na$" required />
                            </div>
                            <div className="form-group col-md-6">
                                <label htmlFor="inputSecondSem" className="col-form-label">Second Semester</label>
                                <input type="text" className="form-control" id="inputSecondSem" placeholder="Enter Second Semester CGPA or NA" onChange={(e) => setSecondSem(e.target.value)} pattern="^[1-9]{1}(\.\d{1,2})?$|^NA$|^Na$|^nA$|^na$" required />
                            </div>
                        </div>

                        <div className="d-flex row">
                            <div className="form-group col-md-6">
                                <label htmlFor="inputThirdSem" className="col-form-label">Third Semester</label>
                                <input type="text" className="form-control" id="inputThirdSem" placeholder="Enter Third Semester CGPA or NA" onChange={(e) => setThirdSem(e.target.value)} pattern="^[1-9]{1}(\.\d{1,2})?$|^NA$|^Na$|^nA$|^na$" required />
                            </div>
                            <div className="form-group col-md-6">
                                <label htmlFor="inputFourthSem" className="col-form-label">Fourth Semester</label>
                                <input type="text" className="form-control" id="inputFourthSem" placeholder="Enter Fourth Semester CGPA or NA" onChange={(e) => setFourthSem(e.target.value)} pattern="^[1-9]{1}(\.\d{1,2})?$|^NA$|^Na$|^nA$|^na$" required />
                            </div>
                        </div>

                        <div className="d-flex row">
                            <div className="form-group col-md-6">
                                <label htmlFor="inputFifthSem" className="col-form-label">Fifth Semester</label>
                                <input type="text" className="form-control" id="inputFifthSem" placeholder="Enter Fifth Semester CGPA or NA" onChange={(e) => setFifthSem(e.target.value)} pattern="^[1-9]{1}(\.\d{1,2})?$|^NA$|^Na$|^nA$|^na$" required />
                            </div>
                            <div className="form-group col-md-6">
                                <label htmlFor="inputSixthSem" className="col-form-label">Sixth Sem</label>
                                <input type="text" className="form-control" id="inputSixthSem" placeholder="Enter Sixth Semester CGPA or NA" onChange={(e) => setSixthSem(e.target.value)} pattern="^[1-9]{1}(\.\d{1,2})?$|^NA$|^Na$|^nA$|^na$" required />
                            </div>
                        </div>

                        <div className="d-flex row">
                            <div className="form-group col-md-6">
                                <label htmlFor="inputSeventhSem" className="col-form-label">Seventh Semester</label>
                                <input type="text" className="form-control" id="inputSeventhSem" placeholder="Enter Seventh Semester CGPA or NA" onChange={(e) => setSeventhSem(e.target.value)} pattern="^[1-9]{1}(\.\d{1,2})?$|^NA$|^Na$|^nA$|^na$" required />
                            </div>
                            <div className="form-group col-md-6">
                                <label htmlFor="inputEightSem" className="col-form-label">Eight Semester</label>
                                <input type="text" className="form-control" id="inputEightSem" placeholder="Enter Eight Semester CGPA or NA" onChange={(e) => setEigthSem(e.target.value)} pattern="^[1-9]{1}(\.\d{1,2})?$|^NA$|^Na$|^nA$|^na$" required />
                            </div>
                        </div>

                        <div className="d-flex submit-reset-buttons">
                            <button type="submit" className="btn btn-success" onClick={(e) => HandleSubmit(e)}>Submit</button>
                            <button type="reset" className="btn btn-danger">Reset</button>
                        </div>
                    </div>
                </form>
                <ClimbingBoxLoader loading={loading} color="#00a885" style={{ margin: "auto" }} />
                {
                    alertBool
                    &&
                    <>
                        <div className="alert alert-info alert-box" role="alert">
                            Data Successfully Added
                        </div>
                    </>
                }
            </div>
           

            <Footer />

        </>
    );
}

export default CreateStudent;