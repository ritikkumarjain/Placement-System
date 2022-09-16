import Header from "../Header/CoordinatorHeader";
import Footer from "../Footer/Footer";
import CreatePhoto from "../../Assests/Images/Create.jpg";
import UpdatePhoto from "../../Assests/Images/Update.jpg";
import ViewPhoto from "../../Assests/Images/View.png";
import { Link, useNavigate } from "react-router-dom";
import { NewsHeaderCard } from "react-ui-cards";
import "./Coordinator.css";
import { useEffect } from "react";

function Coordinator() {
    const navigate = useNavigate();

    function NavigateToCoordinatorsCreate() {
        navigate("/coordinators-menu/create/")
    }

    function NavigateToCoordinatorsUpdate() {
        navigate("/coordinators-menu/update/")
    }

    function NavigateToCoordinatorsView() {
        navigate("/coordinators-menu/view/")
    }

    const localItem = localStorage.getItem("user-info");

    useEffect(() => {
        if (JSON.parse(localItem).identity !== "Coordinator") {
            navigate("/");
            localStorage.removeItem("user-info");
            return;
        }
        
        if (localStorage.getItem("user-info") == null) {
            navigate("/");
            localStorage.removeItem("user-info");
            return;
        }
        

        
    }, [localItem])
    

    return (
        <>
            <Header />
            <div className="coordinator-container" >
                {/* <div className="coordinators-container-main ">
                    <h3>Welcome, TPO</h3>
                </div> */}
                <div className="coordinator-container-main-card">
                    <NewsHeaderCard
                        className="news-header-card"
                        href="#"
                        thumbnail={CreatePhoto}
                        title='Create Data for Student'
                        onClick={() => NavigateToCoordinatorsCreate()}
                    />
                    <NewsHeaderCard
                        className="news-header-card"
                        href='#'
                        thumbnail={UpdatePhoto}
                        title='Update Data of Student'
                        onClick={() => NavigateToCoordinatorsUpdate()}
                    />
                    <NewsHeaderCard
                        className="news-header-card"
                        href='#'
                        thumbnail={ViewPhoto}
                        title='View Data of Student'
                        onClick={() => NavigateToCoordinatorsView()}
                    />
                </div>
            </div>
            <Footer />
        </>
    );
}

export default Coordinator;