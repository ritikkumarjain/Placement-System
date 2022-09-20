
import "./StudentTable.css";


export default function BasicTable(props) {
    return (
        <div className="details-table table-responsive" style={{width: "600px", overflow: "auto", margin: "auto"}}>
            <table className="table table-striped table-bordered">
                    {
                        props.data.map((val) =>
                            <tbody >
                                <tr>
                                    <td>Name</td>
                                    <td>{val.name}</td>
                                </tr>
                                <tr>
                                    <td>University ID</td>
                                    <td>{val.universityId}</td>
                                </tr>
                                <tr>
                                    <td>Registration Number</td>
                                    <td>{val.registrationNumber}</td>
                                </tr>
                                <tr>
                                    <td>Semester</td>
                                    <td>{val.semester}</td>
                                </tr>
                                <tr>
                                    <td>Department</td>
                                    <td>{val.department}</td>
                                </tr>
                                <tr>
                                    <td>First Semester CGPA</td>
                                    <td>{val.firstSem}</td>
                                </tr>
                                <tr>
                                    <td>Second Semester CGPA</td>
                                    <td>{val.secondSem}</td>
                                </tr>
                                <tr>
                                    <td>Third Semester CGPA</td>
                                    <td>{val.thirdSem}</td>
                                </tr>
                                <tr>
                                    <td>Fourth Semester CGPA</td>
                                    <td>{val.fourthSem}</td>
                                </tr>
                                <tr>
                                    <td>Fifth Semester CGPA</td>
                                    <td>{val.fifthSem}</td>
                                </tr>
                                <tr>
                                    <td>Sixth Semester CGPA</td>
                                    <td>{val.sixthSem}</td>
                                </tr>
                                <tr>
                                    <td>Seventh Semester CGPA</td>
                                    <td>{val.seventhSem}</td>
                                </tr>
                                <tr>
                                    <td>Eight Semester CGPA</td>
                                    <td>{val.eigthSem}</td>
                                </tr>
                            </tbody>
                        )}
                
            </table>
        </div>
    );
}
