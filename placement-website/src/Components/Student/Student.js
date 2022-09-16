import React, { useEffect } from 'react';
import { useNavigate } from "react-router-dom";
import { NewsHeaderCard } from "react-ui-cards";
import CreatePhoto from "../../Assests/Images/Create.jpg";
import UpdatePhoto from "../../Assests/Images/Update.jpg";
import ViewPhoto from "../../Assests/Images/View.png";
import Footer from "../Footer/Footer";
import Header from "../Header/Header";
import "./Student.css";


function Student() {
    const navigate = useNavigate();
    function NavigateToStudentCreate() {
        navigate("/students-menu/create/")
    }

    function NavigateToStudentUpdate() {
        navigate("/students-menu/update/")
    }

    function NavigateToStudentView() {
        navigate("/students-menu/view/")
    }

    const localItem = localStorage.getItem("user-info");

    useEffect(() => {
        if (localStorage.getItem("user-info") == null) {
            navigate("/");
            localStorage.removeItem("user-info");
            return;
        }
        if (JSON.parse(localItem).identity !== "Student") {
            navigate("/");
            localStorage.removeItem("user-info");
            return;
        }


    }, [localItem])

    return (
        <>
            <Header />
            <div className="students-container" >
                {/* <div className="students-container-main ">
                    <h3>Welcome, Name</h3>
                </div> */}
                <div className="students-container-main-card">
                    <NewsHeaderCard
                        className="news-header-card"
                        href="#"
                        thumbnail={CreatePhoto}
                        title='Enter Data'
                        onClick={() => NavigateToStudentCreate()}
                    />
                    <NewsHeaderCard
                        className="news-header-card"
                        href='#'
                        thumbnail={UpdatePhoto}
                        title='Update Data'
                        onClick={() => NavigateToStudentUpdate()}
                    />
                    <NewsHeaderCard
                        className="news-header-card"
                        href='#'
                        thumbnail={ViewPhoto}
                        title='View Data'
                        onClick={() => NavigateToStudentView()}
                    />
                </div>
            </div>
            <Footer />
        </>
    );
}

export default Student; 