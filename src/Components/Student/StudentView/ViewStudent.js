import Header from "../../Header/Header";
import Footer from "../../Footer/Footer";
import StudentTable from "./StudentTable";
import { useNavigate } from "react-router-dom";
import React, { useEffect, useState, useRef } from 'react';
import ClimbingBoxLoader from "react-spinners/ClimbingBoxLoader";



function ViewStudent() {
    const [universityId, setUniversityId] = useState("");
    const [registrationNumber, setRegistrationNumber] = useState("");
    const localItem = JSON.parse(localStorage.getItem("user-info"));
    const formRef = useRef(null);
    const navigate = useNavigate();
    const [alertBool,setAlertBool] = useState(false);
    const [retrieved,setRetrieved] = useState([]);
    const [loading,setLoading] = useState(false);

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

        await fetch(`https://localhost:44388/api/Students/ViewStudentsData/${universityId}/${registrationNumber}`)
            .then(response => response.json())
            .then(data => {
                if (data.status === 404) {
                    alert("Something went wrong");
                    return;
                }
                if (data) {
                    var dataObject = [data];
                    setRetrieved([...dataObject]);
                    setLoading(false);
                    setAlertBool(true);
                    return;
                }
                setRetrieved([]);
                setAlertBool(false);
                setLoading(false);

            })
            .catch(error => {
                setLoading(false);
                alert("Error Occured.Please Check inputs");
                window.location.reload();
    
            });
    };

   

    return (
        <>
            <Header />
            <div className="student-create-container">
                <form ref={formRef}>
                    <div className="form-group">
                        <div className="d-flex row justify-content-center">
                            <div className="form-group col-md-4">
                                <label htmlFor="inputUniverityId" className="col-form-label">UniversityId</label>
                                <input type="text" className="form-control" id="inputUniversityId" placeholder="Enter University Id" value={universityId} disabled/>
                                
                            </div>
                            <div className="form-group col-md-4">
                                <label htmlFor="inputRegistrationNumber" className="col-form-label">Registration No.</label>
                                <input type="text" className="form-control" id="inputRegistrationNumber" placeholder="Enter Registration Number" onChange={(e)=>setRegistrationNumber(e.target.value)} required/>
                            </div>
                        </div>
                    </div>
                    <div className="d-flex submit-reset-buttons justify-content-center">
                        <button type="submit" className="btn btn-success col-md-4" onClick={(e) => HandleSubmit(e)}>Submit</button>
                        <button type="reset" className="btn btn-danger col-md-4" onClick={(e) => window.location.reload()}>Reset</button>
                    </div>
                </form>
                {
                    alertBool &&
                    <>
                        <ClimbingBoxLoader loading={loading} color="#00a885" style={{margin: "auto"}}/>
                        <StudentTable data={retrieved} />
                    </>
                }
                

            </div>
            <Footer />
        </>
    );
}

export default ViewStudent;