
import "./CoordinatorView.css";


export default function BasicTable(props) {
    return (
        <div className="details-table table-responsive" style={{ width: "600px", overflow: "auto", margin: "auto" }}>
            <table className="table table-striped table-bordered">
                {
                    props.data.map((val)=>
                    
                
                <tbody>
                    
                    <tr>
                        <td>University Id</td>
                        <td>{val.universityId}</td>
                    </tr>
                    <tr>
                        <td>Registration Number</td>
                        <td>{val.registrationNumber}</td>
                    </tr>
                    <tr>
                        <td>Placement Type I</td>
                        <td>{val.placementTypeI}</td>
                    </tr>
                    <tr>
                        <td>Placement Company I</td>
                        <td>{val.placementCompanyI}</td>
                    </tr>
                    <tr>
                        <td>Placement Type II</td>
                        <td>{val.placementTypeII}</td>
                    </tr>
                    <tr>
                        <td>Placement Company II</td>
                        <td>{val.placementCompanyII}</td>
                    </tr>
                </tbody>
                    
                    )}
            </table>
        </div>
    );
}
