import React, { useEffect } from "react";

export const Error: React.FC = () => {
    useEffect(() => {
        document.title = "Error - My React Application";
    }, []);

    return (
        <div>
            <h1 className="text-danger">Error.</h1>
            <h2 className="text-danger">An error occurred while processing your request.</h2>
        </div>
    );
};
